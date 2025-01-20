using OpenGL_App.Engine.Componoent;
using OpenGL_App.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL_App.Engine
{
    public class GameObject : TreeNode
    {
        public List<UserControl> componentList = new List<UserControl>();
        public GameObject(string text) : base(text)
        {
            BasicInformation component = new BasicInformation(this);
            component.Dock = DockStyle.Top;
            componentList.Add(component);

            if (text != "Scene Root")
            {
                Transformation transformControl = new Transformation();
                transformControl.Dock = DockStyle.Top;
                componentList.Add(transformControl);
            }
            
        }

        public SearchInterface getComponentForInterfaceType<SearchInterface>()
        {
            return this.componentList.OfType<SearchInterface>().FirstOrDefault();
        }
    }
}
