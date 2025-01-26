using ObjLoader.Loader.Common;
using OpenTK.Mathematics;
using System.ComponentModel;
using System.Diagnostics;
using Übung.engine;
using Übung.engine.Interfaces;

namespace Übung
{
    public partial class SceneManager : System.Windows.Forms.TreeView
    {
        public Form1 form { get; set; }
        public ComponentManager ComponentManager { get; set; }
        public static SceneManager Instance = null;

        ContextMenuStrip contextMenuStrip = null;

        void Init()
        {
            Instance = this;
            InitializeComponent();
            this.NodeMouseClick += new TreeNodeMouseClickEventHandler(onMouseClick);
        }
        public SceneManager()
        {
            Init();            
        }

        public SceneManager(IContainer container)
        {
            Init();
            container.Add(this);

            // create context menu
            contextMenuStrip = new ContextMenuStrip();

            ToolStripLabel lbl = new ToolStripLabel("Add new");
            lbl.Tag = "new";
            contextMenuStrip.Items.Add(lbl);

            ToolStripLabel lbl2 = new ToolStripLabel("Delete");
            lbl2.Tag = "del";
            contextMenuStrip.Items.Add(lbl2);
            contextMenuStrip.ItemClicked += new ToolStripItemClickedEventHandler(onMenuSelect);

            TreeNode root = new TreeNode("Scene Root");
            root.ContextMenuStrip = contextMenuStrip;
            this.Nodes.Add(root);            

            // Add event handlers for the required drag events.
            this.ItemDrag += new ItemDragEventHandler(this_ItemDrag);
            this.DragEnter += new DragEventHandler(this_DragEnter);
            this.DragOver += new DragEventHandler(this_DragOver);
            this.DragDrop += new DragEventHandler(this_DragDrop);
            AllowDrop = true;
        }     
        
        public void LoadModel(string path)
        {
            if (path.IsNullOrEmpty() || !File.Exists(path))
                return;

            GameObject go = newGameObject("Default") as GameObject;
            go.LoadMesh(path, true);
            this.Nodes[0].Nodes.Add(go);
        }

        private void onMouseClick(object? sender, TreeNodeMouseClickEventArgs e)
        {
            GameObject gameObject = e.Node as GameObject;
            if (gameObject != null)
            {
                string tag = e.Node.Tag as string;
                if (tag == "GameObject")
                {
                    GameObject go = e.Node as GameObject;
                    if (go != null)
                    {
                        Debug.WriteLine("clicked on " + go.ToString());
                        ComponentManager.Instance.displayComponents(gameObject);
                    }
                }
            }
        }

        #region DragNDrop
        // ref https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.treeview.itemdrag?view=windowsdesktop-7.0
        private void this_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // Move the dragged node when the left mouse button is used.
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }

            // Copy the dragged node when the right mouse button is used.
            else if (e.Button == MouseButtons.Right)
            {
                DoDragDrop(e.Item, DragDropEffects.Copy);
            }
        }

        // Set the target drop effect to the effect 
        // specified in the ItemDrag event handler.
        private void this_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        // Select the node under the mouse pointer to indicate the 
        // expected drop location.
        private void this_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse position.
            Point targetPoint = this.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.
            this.SelectedNode = this.GetNodeAt(targetPoint);
        }

        private void this_DragDrop(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the drop location.
            Point targetPoint = this.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.
            TreeNode targetNode = this.GetNodeAt(targetPoint);

            // Retrieve the node that was dragged.
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(GameObject));

            // Confirm that the node at the drop location is not 
            // the dragged node or a descendant of the dragged node.
            if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode))
            {
                // If it is a move operation, remove the node from its current 
                // location and add it to the node at the drop location.
                if (e.Effect == DragDropEffects.Move)
                {
                    draggedNode.Remove();
                    targetNode.Nodes.Add(draggedNode);
                }

                // If it is a copy operation, clone the dragged node 
                // and add it to the node at the drop location.
                else if (e.Effect == DragDropEffects.Copy)
                {
                    targetNode.Nodes.Add((TreeNode)draggedNode.Clone());
                }

                // Expand the node at the location 
                // to show the dropped node.
                targetNode.Expand();
            }
        }

        // Determine whether one node is a parent 
        // or ancestor of a second node.
        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            // Check the parent node of the second node.
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;

            // If the parent node is not null or equal to the first node, 
            // call the ContainsNode method recursively using the parent of 
            // the second node.
            return ContainsNode(node1, node2.Parent);
        }
        #endregion

        TreeNode newGameObject(string name="GameObject", string tag="GameObject")
        {
            TreeNode go = new GameObject(name);
            go.ContextMenuStrip = contextMenuStrip;
            go.Text = name;
            go.Tag = tag;
            return go;
        }       

        private void onMenuSelect(object? sender, ToolStripItemClickedEventArgs e)
        {
            string tag = e.ClickedItem.Tag as string;
            Debug.WriteLine(tag);
            switch (tag)
            {
                case "new":
                    TreeNode node = this.SelectedNode;
                    ToolStrip toolStrip = e.ClickedItem.GetCurrentParent();
                    TreeNode currentGameObject = newGameObject();
                    node.Nodes.Add(currentGameObject);
                    break;
                
                case "del":
                    {
                        TreeNode currentNode = this.SelectedNode;
                        if (currentNode != null && currentNode is GameObject)
                        {
                            currentNode.Parent.Nodes.Remove(currentNode);
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        public void doRenderScene()
        {
            foreach (GameObject node in this.Nodes[0].Nodes) // for all childs of root
            {
                renderGameObject(node, Matrix4.Identity);
            }
        }

        private void renderGameObject(GameObject gameobj, Matrix4 parentTransformation)
        {
            Matrix4 currentTransformation = Matrix4.Identity;
            // Prüfen, ob das GameObject Komponenten mit IRenderAble enthält und rendern falls ja
            if (gameobj.getComponentForInterfaceType<IRenderAble>() != null)
            {
                currentTransformation = gameobj.getComponentForInterfaceType<IRenderAble>().doRender(parentTransformation);
            }

            // Rekursiv die children durchlaufen
            foreach (GameObject child in gameobj.Nodes)
            {
                renderGameObject(child, currentTransformation);
            }
        }

        //void renderGameObject2(GameObject go)
        //{
        //    if (go == null) return;

        //    foreach (GameObject node in go.Nodes)
        //    {
        //        renderGameObject2(node);
        //    }

        //    go.doRender();
        //}
    }
}
