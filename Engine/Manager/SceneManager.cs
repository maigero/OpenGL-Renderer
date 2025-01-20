using OpenGL_App.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenGL_App.Engine.Manager
{
    public partial class SceneManager : TreeView
    {
        public SceneManager()
        {
            InitializeComponent();
            this.init();
        }

        private void init()
        {
            this.Nodes.Clear();
            GameObject node = new GameObject("Scene Root");
            this.addContextMenu(
                node,
                new (string, string)[]
                {
                    ("Add GameObject", "add")
                }
            );

            this.Nodes.Add(node);
            this.initDragAndDrop();
            this.NodeMouseClick += new TreeNodeMouseClickEventHandler(onNodeMouseClick);
        }
    

        private void onNodeMouseClick(object? sender, TreeNodeMouseClickEventArgs e)
        {
            GameObject gameObj = e.Node as GameObject;
            if (gameObj != null)
            {
                ComponentManager.Instance.displayComponents(gameObj);
            }
        }

        public void addNewNode(TreeNode? parentNode)
        {
            GameObject node = new GameObject("GameObject");
            this.addContextMenu(
                node,
                new (string, string)[]
                {
                    ("Add GameObject", "add"),
                    ("Delete GameObject", "del")
                }
            );
            parentNode?.Nodes.Add(node);
            parentNode?.Expand();
        }

        private void onNodeMenuItemClicked(object? sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Tag)  // get command from event arguments
            {
                case "add":
                    this.addNewNode(this.SelectedNode);
                    break;

                case "del":
                    this.Nodes.Remove(this.SelectedNode);
                    break;
            }
        }

        private void addContextMenu(TreeNode node, (string, string)[] menuItems)
        {
            ContextMenuStrip menuStrip = new ContextMenuStrip();  // new context Menu for tree node
            menuStrip.ItemClicked += new ToolStripItemClickedEventHandler(onNodeMenuItemClicked); // register nodeMenuItemClicked function for ItemClicked event
            foreach ((string, string) item in menuItems)
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem(item.Item1);
                menuItem.Tag = item.Item2;  // tag is used for command !!
                menuStrip.Items.Add(menuItem);
            }
            node.ContextMenuStrip = menuStrip;
        }

        public void doRenderScene ()
        {
            renderGameObject((GameObject)this.Nodes[0]);
        }

        private void renderGameObject(GameObject gameobj)
        {
            gameobj.getComponentForInterfaceType<IRenderAble>()?.doRender();

            foreach (GameObject chield in gameobj.Nodes)
            {
                renderGameObject(chield);
            }
        }

        #region Drag and Drop
        // ref https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.treeview.itemdrag?view=windowsdesktop-7.0
        private void initDragAndDrop()
        {
            this.AllowDrop = true;
            this.ItemDrag += new ItemDragEventHandler(treeView1_ItemDrag);
            this.DragEnter += new DragEventHandler(treeView1_DragEnter);
            this.DragOver += new DragEventHandler(treeView1_DragOver);
            this.DragDrop += new DragEventHandler(treeView1_DragDrop);
        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeNode draggedNode = e.Item as TreeNode;

            if (draggedNode != null && draggedNode.Text == "Scene Root")
            {
                return;
            }

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
        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            if((sender as SceneManager).SelectedNode is GameObject)
            {
                e.Effect = e.AllowedEffect;
            }
        }

        // Select the node under the mouse pointer to indicate the 
        // expected drop location.
        private void treeView1_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse position.
            Point targetPoint = this.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.
            this.SelectedNode = this.GetNodeAt(targetPoint);
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
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
    }
}