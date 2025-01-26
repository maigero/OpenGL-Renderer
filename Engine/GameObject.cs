using OpenTK.Mathematics;
using Übung.engine.component;
using OpenTK.Graphics.OpenGL;
using OpenGL_App.Engine.Componoent;

namespace Übung.engine
{
    public class GameObject : TreeNode
    {
        public List<UserControl> componentList = new List<UserControl>();

        static uint counterTotal = 0;
        uint counter = 0;

        public uint Counter { get => counter; }

        public T getComponentForInterface<T>() where T : class
        {
            foreach (var component in componentList)
            {
                if (component is T interfaceComponent)
                {
                    return interfaceComponent;
                }
            }
            return null; // Keine passende Komponente gefunden
        }

        public T getComponentForInterfaceType<T>()
        {
            return this.componentList.OfType<T>().FirstOrDefault();
        }
        void init()
        {
            counter = counterTotal;
            counterTotal++;
        }

        public GameObject(string name) : base(name)
        {
            init();
            Name = name;
            BasicInformation component = new BasicInformation(this);
            component.Dock = DockStyle.Top;
            componentList.Add(component);
            Transformation transformationComp = new Transformation(this);
            componentList.Add(transformationComp);            
        }

        public void AddMeshRenderer()
        {
            componentList.Add(new MeshRenderer(this));
            ComponentManager.Instance.displayComponents(this);
        }

        public override string ToString()
        {
            Transformation transformationComp = getComponentForInterfaceType<Transformation>();
            return $"GameObject #{counter}: {this.Text}:{transformationComp.ToString()}";
        }

        public void Update()
        {
            this.Text = Name;
        }

        /*public void doRender()
        {
            MeshRenderer renderer = componentList[1] as MeshRenderer;
            if (renderer != null)
            {
                GL.PushMatrix();
                GL.Rotate(rotation.X, 1, 0, 0);
                GL.Rotate(rotation.Y, 0, 1, 0);
                GL.Rotate(rotation.Z, 0, 0, 1);
                GL.Scale(scale);
                GL.Translate(translation);

                renderer.doRender();
                GL.PopMatrix();
            }
        }*/

        public void LoadMesh(string path, bool addMeshRenderer = false)
        {
            if (addMeshRenderer)
            {
                AddMeshRenderer();
            }

            MeshRenderer renderer = getComponentForInterfaceType<MeshRenderer>();
            if (renderer != null)
            {
                renderer.LoadMesh(path);
            }

        }
    }
}