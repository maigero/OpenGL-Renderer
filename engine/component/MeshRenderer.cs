using ObjLoader.Loader.Data;
using ObjLoader.Loader.Data.Elements;
using ObjLoader.Loader.Loaders;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using Übung.engine.Interfaces;
using ImageMagick;
using Übung.shader;
using System.Windows.Forms;

namespace Übung.engine.component
{
    public struct GROUP_OBJECT_RENDER_INFO
    {
        public int lineVertexCount; // Anzahl der Linien-Vertices
        public int triangleVertexCount; // Anzahl der Dreiecks-Vertices
        public int textureHandle; // Textur-Handle
        public int vaoTriangleUVHandle; // VAO-Handle für Dreiecke mit UV
        public int vaoLineHandle; // VAO-Handle für Linien
    }
    public partial class MeshRenderer : UserControl, IRenderAble
    {
        LoadResult modelData;

        GameObject? gameObj = null;
        int _vboHandle = 0;
        int _vaoHandle = 0;

        int _triangleCnt = 0;
        int _lineCnt = 0;
        int _uvCnt = 0;

        Shader _shaderHost = null;
        Vec3 color = new Vec3(0.8f, 0.8f, 0.8f);

        string fullPath;

        List<GROUP_OBJECT_RENDER_INFO> _renderInfo = new List<GROUP_OBJECT_RENDER_INFO>();

        public MeshRenderer(GameObject gameObj) : base()
        {
            InitializeComponent();
            this.gameObj = gameObj;
            addContextMenu();
            this._shaderHost = new Shader(@"./shader/vertex.shader", @"./shader/fragment.shader"); // create new Shader object and load Shaders
        }

        public MeshRenderer()
        {
            InitializeComponent();
        }

        private void addContextMenu()
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem.Click += new EventHandler(onDelete);
            menuItem.Text = "delete MeshRenderer";
            this.ContextMenuStrip = new ContextMenuStrip();
            this.ContextMenuStrip.Items.Add(menuItem);
        }
       
        private void onDelete(object? sender, EventArgs e)
        {
            this.gameObj.componentList.Remove(this);
            ComponentManager.Instance.displayComponents(this.gameObj);
        }

        private void buttonLoadMesh_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                LoadMesh(openFileDialog1.FileName);
            }
        }

        public void LoadMesh(String path)
        {
            string name = Path.GetFileNameWithoutExtension(path);
            this.fullPath = Path.GetDirectoryName(path);
            var objLoaderFactory = new ObjLoaderFactory();
            var objLoader = objLoaderFactory.Create();
            var fileStream = new FileStream(path, FileMode.Open);
            this.modelData = objLoader.Load(fileStream);
            fileStream.Close();
            this.buildDataInformation();
            this.InitializeBuffer();

            if (this.modelData.Materials.Count > 0 && this.modelData.Materials[0] != null)
            {
                this.color = this.modelData.Materials[0].DiffuseColor;
            }
        }

        private void buildDataInformation()
        {
            this.textBox1.Text = "";
            this.textBox1.Text += String.Format("Anzahl Objekte: {0}", this.modelData.Groups.ToArray().Length) + Environment.NewLine;
            this.textBox1.Text += String.Format("Unique Eckpunkte: {0}", this.modelData.Vertices.ToArray().Length) + Environment.NewLine;

            int cnt = 1;
            foreach (Group group in modelData.Groups)
            {
                int faces = group.Faces.ToArray().Length;
                this.textBox1.Text += String.Format("{0} {1}", group.Name, cnt) + Environment.NewLine;
                this.textBox1.Text += String.Format("  Faces: {0}", faces) + Environment.NewLine;
                this.textBox1.Text += String.Format("  V-Cnt: {0}", faces * 3) + Environment.NewLine;
                this.textBox1.Text += String.Format("  Has texture: {0}", group.Material?.DiffuseTextureMap != null) + Environment.NewLine;
                cnt++;
            }
        }

        private void InitializeBuffer()
        {
            this._vaoHandle = GL.GenVertexArray();
            GL.BindVertexArray(this._vaoHandle);

            this._vboHandle = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, this._vboHandle);

            List<float> groupTriangleVertexList = new List<float>();
            List<float> groupLineVertexList = new List<float>();
            List<float> vertexList = new List<float>();

            // loop over groups
            foreach (Group group in this.modelData.Groups)
            {
                if (group.Material != null && group.Material.DiffuseTextureMap != null)
                {
                    GROUP_OBJECT_RENDER_INFO group_object_render_info = new GROUP_OBJECT_RENDER_INFO();

                    MagickImage img = new MagickImage(fullPath + "/" + group.Material.DiffuseTextureMap);
                    img.Flip(); // flip image for correct texture display
                    group_object_render_info.textureHandle = GL.GenTexture();

                    GL.ActiveTexture(TextureUnit.Texture0);
                    GL.BindTexture(TextureTarget.Texture2D, group_object_render_info.textureHandle);

                    byte[]? imgData = img.GetPixels().ToByteArray("RGBa");
                    GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, (int)img.Width, (int)img.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, imgData);

                    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.LinearMipmapLinear);
                    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

                    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
                    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

                    GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

                    // loop over faces
                    foreach (Face face in group.Faces)
                    {
                        for (int vIdx = 0; vIdx < 3; vIdx++)
                        {
                            //Add x,y,z vertex data to triangle vertex list   
                            groupTriangleVertexList.Add(modelData.Vertices[face[vIdx].VertexIndex - 1].X);
                            groupTriangleVertexList.Add(modelData.Vertices[face[vIdx].VertexIndex - 1].Y);
                            groupTriangleVertexList.Add(modelData.Vertices[face[vIdx].VertexIndex - 1].Z);
                            group_object_render_info.triangleVertexCount++;
                            this._triangleCnt++;

                            groupTriangleVertexList.Add(modelData.Textures[face[vIdx].TextureIndex - 1].X);
                            groupTriangleVertexList.Add(modelData.Textures[face[vIdx].TextureIndex - 1].Y);
                            this._uvCnt++;

                            //Add first point x,y,z vertex line data to lineVertexList
                            groupLineVertexList.Add(modelData.Vertices[face[vIdx].VertexIndex - 1].X);
                            groupLineVertexList.Add(modelData.Vertices[face[vIdx].VertexIndex - 1].Y);
                            groupLineVertexList.Add(modelData.Vertices[face[vIdx].VertexIndex - 1].Z);

                            if (vIdx == 2)
                            {
                                //Add second point x,y,z vertex line data to lineVertexList in case endpoint is first triangle point
                                groupLineVertexList.Add(modelData.Vertices[face[0].VertexIndex - 1].X);
                                groupLineVertexList.Add(modelData.Vertices[face[0].VertexIndex - 1].Y);
                                groupLineVertexList.Add(modelData.Vertices[face[0].VertexIndex - 1].Z);
                            }
                            else
                            {
                                //add second point x,y,z vertex line data to lineVertexList 
                                groupLineVertexList.Add(modelData.Vertices[face[vIdx + 1].VertexIndex - 1].X);
                                groupLineVertexList.Add(modelData.Vertices[face[vIdx + 1].VertexIndex - 1].Y);
                                groupLineVertexList.Add(modelData.Vertices[face[vIdx + 1].VertexIndex - 1].Z);
                            }
                            this._lineCnt += 2;
                            group_object_render_info.lineVertexCount += 2;
                        }
                    }

                    group_object_render_info.vaoTriangleUVHandle = GL.GenVertexArray();
                    GL.BindVertexArray(group_object_render_info.vaoTriangleUVHandle);

                    GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), vertexList.Count() * sizeof(float));
                    GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), vertexList.Count() * sizeof(float) + 3 * sizeof(float));
                    GL.EnableVertexAttribArray(0);
                    GL.EnableVertexAttribArray(1);


                    vertexList.AddRange(groupTriangleVertexList);

                    group_object_render_info.vaoLineHandle = GL.GenVertexArray();
                    GL.BindVertexArray(group_object_render_info.vaoLineHandle);
                    GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), vertexList.Count() * sizeof(float));
                    GL.EnableVertexAttribArray(0);

                    vertexList.AddRange(groupLineVertexList);
                    GL.BindVertexArray(0);
                    _renderInfo.Add(group_object_render_info);
                }
            }
            float[] fullVertexData = vertexList.ToArray();
            GL.BufferData(BufferTarget.ArrayBuffer, fullVertexData.Length * sizeof(float), fullVertexData, BufferUsageHint.DynamicDraw);
        }

        public void doRender_OLD()
        {
            if (modelData == null)
                return;
            //Startet das Rendern von Dreiecken
            GL.Begin(PrimitiveType.Triangles);
            // Durchlaufen aller Gruppen
            foreach (var group in modelData.Groups)
            {
                // Setze die Diffuse-Farbe des Materials
                if (group.Material != null)// && group.Material.DiffuseColor != null)
                {
                    // DiffuseColor ist vom Typ vec3
                    var color = group.Material.DiffuseColor;
                    // Setzen der RGB-Werte
                    GL.Color3(color.X, color.Y, color.Z);
                }
                else
                    GL.Color3(255, 255, 255);
                // Durchlaufen aller Faces in der Gruppe
                foreach (var triangle in group.Faces)
                {
                    // Face enthält genau 3 Vertices (Dreiecke)
                    // foreach (var vertex in face. .Vertices)  // indexer 0,1,2
                    for (int i = 0; i < 3; i++)
                    {
                        // Hole die Koordinaten des Vertex aus dem Vertices-Array
                        // VertexIndex ist 1-basiert
                        var position = modelData.Vertices[triangle[i].VertexIndex - 1];
                        // Übergebe die Vertex-Koordinaten an OpenGL
                        GL.Vertex3(position.X, position.Y, position.Z);
                    }
                }
            }
            GL.End(); // Beendet das Rendern
        }

        public Matrix4 doRender(Matrix4 parentTransformation)
        {
            if (modelData == null) return Matrix4.Identity;

            this._shaderHost.Use();
            Matrix4 combinedTransformation = gameObj.getComponentForInterfaceType<IHasTransformationInfo>().transformationData * parentTransformation;
            this._shaderHost.SetMatrix4("transformation", combinedTransformation);
            this._shaderHost.SetMatrix4("projection", Form1.perspective);
            this._shaderHost.SetInt("useColor", 0);
            this._shaderHost.SetVector3("color", new Vector3(Color4.Black.R, Color4.Black.G, Color4.Black.B));

            foreach (GROUP_OBJECT_RENDER_INFO toRender in this._renderInfo)
            {
                GL.BindVertexArray(toRender.vaoTriangleUVHandle);
                GL.ActiveTexture(TextureUnit.Texture0);
                GL.BindTexture(TextureTarget.Texture2D, toRender.textureHandle);
                GL.DrawArrays(PrimitiveType.Triangles, 0, toRender.triangleVertexCount);

                GL.Enable(EnableCap.PolygonOffsetLine);
                GL.PolygonOffset(1.0f, 1.0f);
                GL.BindVertexArray(toRender.vaoLineHandle);
                this._shaderHost.SetInt("useColor", 1);
                this._shaderHost.SetVector3("color", new Vector3(Color4.Black.R, Color4.Black.G, Color4.Black.B));
                GL.LineWidth(2.0f);
                GL.DrawArrays(PrimitiveType.Lines, 0, toRender.lineVertexCount);
                GL.Disable(EnableCap.PolygonOffsetFill);
            }
            return combinedTransformation;
        }
    }
}