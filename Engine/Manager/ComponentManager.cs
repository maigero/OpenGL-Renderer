using OpenGL_App.Engine.Componoent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenGL_App.Engine.Manager
{
    public partial class ComponentManager : FlowLayoutPanel
    {
        public static ComponentManager? Instance = null;

        public GameObject activeGameObj = null;

        public ComponentManager()
        {
            InitializeComponent();
            ComponentManager.Instance = this;
            this.initComponentMenuItems();
        }

        private void initComponentMenuItems()
        {
            this.ContextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem.Click += new EventHandler(onAddComponent);
            menuItem.Text = "Add MeshRenderer";
            menuItem.Tag = "meshrenderer";
            this.ContextMenuStrip.Items.Add(menuItem);

        }

        private void onAddComponent(object? sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            if (menuItem != null)
            {
                switch(menuItem.Tag as string)
                {
                    case "meshrenderer":
                        MeshRenderer meshRenderer = new MeshRenderer(this.activeGameObj);
                        this.activeGameObj.componentList.Add(meshRenderer);
                        this.displayComponents(this.activeGameObj);
                        break;
                }
            }
        }

        public void displayComponents(GameObject gameObejct)
        {
            this.activeGameObj = gameObejct;
            this.Controls.Clear(); // clear controls
            foreach (UserControl control in gameObejct.componentList)    // loop through GameObject 
            {
                control.Width = this.Width;
                this.Controls.Add(control);
            }
        }
    }
}
