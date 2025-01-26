using System.ComponentModel;
using Übung.engine;

namespace Übung
{
    public partial class ComponentManager : FlowLayoutPanel
    {
        public static ComponentManager Instance = null;

        public ComponentManager()
        {
            InitializeComponent();
        }

        void init()
        {
            InitializeComponent();
            Instance = this;
            addContextMenu();
        }

        public ComponentManager(IContainer container)
        {
            container.Add(this);
            init();
        }

        private void addContextMenu()
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem.Click += new EventHandler(onAdd);
            menuItem.Text = "add MeshRenderer";
            this.ContextMenuStrip = new ContextMenuStrip();
            this.ContextMenuStrip.Items.Add(menuItem);
        }

        private void onAdd(object? sender, EventArgs e)
        {
            GameObject currentGameObject = SceneManager.Instance.SelectedNode as GameObject;
            if (currentGameObject == null)
                return;
            currentGameObject.AddMeshRenderer();
        }

        public void displayComponents(GameObject gameObject)
        {
            if (!gameObject.Name.Contains("Root"))
            {
                this.Controls.Clear();
                foreach (UserControl control in gameObject.componentList)
                {
                    control.Width = this.Width;
                    this.Controls.Add(control);
                }
            }
        }
    }
}
