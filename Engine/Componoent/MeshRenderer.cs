using _3D_GFX_Exercises.shader;
using ObjLoader.Loader.Data;
using ObjLoader.Loader.Data.Elements;
using ObjLoader.Loader.Loaders;
using OpenGL_App.Engine.Interfaces;
using OpenGL_App.Engine.Manager;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using ImageMagick;
using System.Runtime.CompilerServices;


namespace OpenGL_App.Engine.Componoent
{
    public partial class MeshRenderer : UserControl , IRenderAble
    {
        GameObject? gameObj = null;
        private int _vboHandle = 0;

        private int _triangleCnt = 0;
        private int _lineCnt = 0;

        private Shader _shaderHost = null;
        private Vec3 color = new Vec3(0.8f, 0.8f, 0.8f);

        private LoadResult modelData = null;

        // TEST
        private Vector3 _modelCenter = Vector3.Zero;
        private float _minX, _minY, _minZ;
        private float _maxX, _maxY, _maxZ;
        // TEST
        public struct GROUP_OBJECT_RENDER_INFO
        {
            public int lineVertexCount;
            public int triangleVertexCount;
            public int textureHandle;
            public int vaoTriangleUVHandle;
            public int vaoLineHandle;
        }

        private List<GROUP_OBJECT_RENDER_INFO> _renderInfo = new List<GROUP_OBJECT_RENDER_INFO> ();

        private List<float> _bufferData = new List<float> ();

        public MeshRenderer()
        {
            InitializeComponent();
        }

        public MeshRenderer(GameObject gameObj) : base()
        {
            InitializeComponent();
            this.gameObj = gameObj;
            this.InitDeleteMenu();
            this._shaderHost = new Shader(@"./shader/vertex.shader", @"./shader/fragment.shader"); // create new Shader object and load Shaders

        }

        private void InitDeleteMenu()
        {
            this.ContextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem.Click += new EventHandler(onDelete);
            menuItem.Text = "Delete MeshRenderer";
            menuItem.Tag = "meshrenderer";
            this.ContextMenuStrip.Items.Add(menuItem);
        }


        private void onDelete(object? sender, EventArgs e)
        {
            this.gameObj.componentList.Remove(this);
            ComponentManager.Instance.displayComponents(this.gameObj);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = this.openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fullPath = this.openFileDialog1.FileName;
                string baseDir = Path.GetDirectoryName(fullPath);
                var objLoaderFactory = new ObjLoaderFactory();
                var objLoader = objLoaderFactory.Create();
                var fileStream = new FileStream(fullPath, FileMode.Open);
                this.modelData = objLoader.Load(fileStream);
                fileStream.Close();

                // TEST
                CalculateModelCenter();

                var transformComp = this.gameObj?.componentList.OfType<Transformation>().FirstOrDefault();
                if(transformComp != null)
                {
                    transformComp.PivotShift = _modelCenter;
                }
                // TEST

                this.buildDataInformaation();
                this.InitializeBuffer(baseDir);

                if (this.modelData.Materials.Count != 0)
                {
                    this.color = this.modelData.Materials[0].DiffuseColor;
                }

            }
        }

        private void InitializeBuffer(string basePath)
        {
            // Clear previous rendering information and buffer data
            _renderInfo.Clear();
            _bufferData.Clear();

            // Generate a new buffer object and bind it to the ArrayBuffer target
            _vboHandle = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vboHandle);

            // Iterate over each group in the model data
            foreach (Group group in this.modelData.Groups)
            {
                // Create an object to extend rendering information for each group
                GROUP_OBJECT_RENDER_INFO groupInfo = new GROUP_OBJECT_RENDER_INFO();
                groupInfo.vaoTriangleUVHandle = 0;
                groupInfo.vaoLineHandle = 0;

                // Load texture if it exists
                if (group.Material?.DiffuseTextureMap != null)
                {
                    string texFullpath = Path.Combine(basePath, group.Material.DiffuseTextureMap);
                    groupInfo.textureHandle = LoadTexture(texFullpath);
                }
                else
                {
                    groupInfo.textureHandle = 0;
                }

                // Create lists to hold vertex and line data
                List<float> triangleUVData = new List<float>();
                List<float> lineData = new List<float>();

                // Iterate through each face to extract vertex information
                foreach (Face face in group.Faces)
                {
                    // Iterate over vertices in the face to gather position and texture data
                    for (int vIdx = 0; vIdx < 3; vIdx++)
                    {
                        // Retrieve vertex position information
                        int pIndex = face[vIdx].VertexIndex - 1;
                        float px = this.modelData.Vertices[pIndex].X;
                        float py = this.modelData.Vertices[pIndex].Y;
                        float pz = this.modelData.Vertices[pIndex].Z;

                        // Initialize texture coordinates
                        float ux = 0.0f;
                        float uy = 0.0f;

                        // Retrieve texture coordinates if available
                        if (face[vIdx].TextureIndex > 0 && face[vIdx].TextureIndex <= this.modelData.Textures.Count)
                        {
                            var uv = this.modelData.Textures[face[vIdx].TextureIndex - 1];
                            ux = uv.X;
                            uy = uv.Y;
                        }

                        // Add vertex attributes to the list (position + texture)
                        triangleUVData.Add(px);
                        triangleUVData.Add(py);
                        triangleUVData.Add(pz);
                        triangleUVData.Add(ux);
                        triangleUVData.Add(uy);
                    }

                    // Extract line data for edges of the face
                    for (int edgeIdx = 0; edgeIdx < 3; edgeIdx++)
                    {
                        int startV = edgeIdx;
                        int endV = (edgeIdx + 1) % 3;

                        // Retrieve start vertex of the edge
                        int sIndex = face[startV].VertexIndex - 1;
                        float sx = this.modelData.Vertices[sIndex].X;
                        float sy = this.modelData.Vertices[sIndex].Y;
                        float sz = this.modelData.Vertices[sIndex].Z;

                        // Retrieve end vertex of the edge
                        int eIndex = face[endV].VertexIndex - 1;
                        float ex = this.modelData.Vertices[eIndex].X;
                        float ey = this.modelData.Vertices[eIndex].Y;
                        float ez = this.modelData.Vertices[eIndex].Z;

                        // Add line data (start and end positions)
                        lineData.Add(sx);
                        lineData.Add(sy);
                        lineData.Add(sz);
                        lineData.Add(ex);
                        lineData.Add(ey);
                        lineData.Add(ez);
                    }
                }

                // Update counts of vertices
                groupInfo.triangleVertexCount = triangleUVData.Count / 5;
                groupInfo.lineVertexCount = lineData.Count / 3;

                // Offset for the current batch of data in global buffer data
                int currentGroupOffset = _bufferData.Count;

                // Add calculated face and edge data to the global buffers
                _bufferData.AddRange(triangleUVData);
                _bufferData.AddRange(lineData);

                // Append this group's information to render info list
                _renderInfo.Add(groupInfo);
            }

            // Upload buffer data to the GPU via OpenGL buffer
            GL.BufferData(
                BufferTarget.ArrayBuffer,
                _bufferData.Count * sizeof(float),
                _bufferData.ToArray(),
                BufferUsageHint.StaticDraw
            );

            int offset = 0;
            for (int i = 0; i < _renderInfo.Count; i++)
            {
                var info = _renderInfo[i];

                // Handle the VertexArrayObject for the triangle rendering
                info.vaoTriangleUVHandle = GL.GenVertexArray();
                GL.BindVertexArray(info.vaoTriangleUVHandle);
                GL.BindBuffer(BufferTarget.ArrayBuffer, _vboHandle);

                // Define the vertex attribute layout (position)
                GL.EnableVertexAttribArray(0);
                GL.VertexAttribPointer(
                    0,
                    3,
                    VertexAttribPointerType.Float,
                    false,
                    5 * sizeof(float), // stride
                    (IntPtr)(offset * sizeof(float))
                );

                // Define the texture attribute layout
                GL.EnableVertexAttribArray(1);
                GL.VertexAttribPointer(
                    1,
                    2,
                    VertexAttribPointerType.Float,
                    false,
                    5 * sizeof(float), // stride
                    (IntPtr)((offset + 3) * sizeof(float))
                );

                // Handle the VertexArrayObject for the line rendering
                info.vaoLineHandle = GL.GenVertexArray();
                GL.BindVertexArray(info.vaoLineHandle);
                GL.BindBuffer(BufferTarget.ArrayBuffer, _vboHandle);

                // Offset for line vertex data
                int lineOffset = offset + info.triangleVertexCount * 5;

                GL.EnableVertexAttribArray(0);
                GL.VertexAttribPointer(
                    0,
                    3,
                    VertexAttribPointerType.Float,
                    false,
                    3 * sizeof(float), // stride (vertices carry only position information)
                    (IntPtr)(lineOffset * sizeof(float))
                );

                GL.BindVertexArray(0);

                // Compute total size needed for this group in global buffer data
                int totalGroup = (info.triangleVertexCount * 5) + (info.lineVertexCount * 3);
                offset += totalGroup;

                // Update corresponding render info data
                _renderInfo[i] = info;
                GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            }
        }

        // Helper method for loading
        private int LoadTexture(string texFullPath)
        {
            int texHandle = GL.GenTexture();
            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, texHandle);

            using (var img = new MagickImage(texFullPath))
            {
                img.Flip();

                byte[] imgData = img.GetPixels().ToByteArray("RGBA");

                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, (int)img.Width, (int)img.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, imgData);
            }

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.LinearMipmapLinear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            // Unbind
            GL.BindTexture(TextureTarget.Texture2D, 0);
            return texHandle;
        }
       
        private void CalculateModelCenter()
        {
            _minX = float.MaxValue;
            _minY = float.MaxValue;
            _minZ = float.MaxValue;
            _maxX = float.MinValue;
            _maxY = float.MinValue;
            _maxZ = float.MinValue;

            foreach (var v in this.modelData.Vertices)
            {
                _minX = Math.Min(_minX, v.X);
                _minY = Math.Min(_minY, v.Y);
                _minZ = Math.Min(_minZ, v.Z);
                _maxX = Math.Max(_maxX, v.X);
                _maxY = Math.Max(_maxY, v.Y);
                _maxZ = Math.Max(_maxZ, v.Z);
            }

            float centerX = 0.5f * (_minX + _maxX);
            float centerY = 0.5f * (_minY + _maxY);
            float centerZ = 0.5f * (_minZ + _maxZ);

            _modelCenter = new Vector3(centerX, centerY, centerZ);
        }

        private void buildDataInformaation()
        {
            this.textBox1.Text = "";
            this.textBox1.Text += $"Anzahl Objekte: {this.modelData.Groups.Count}\r\n";
            this.textBox1.Text += $"Unique Eckpunkte: {this.modelData.Vertices.Count}\r\n\r\n";


            // TEST
            this.textBox1.Text += $"Bounds Min: ({_minX}, {_minY}, {_minZ})\r\n";
            this.textBox1.Text += $"Bounds Max: ({_maxX}, {_maxY}, {_maxZ})\r\n\r\n";

            this.textBox1.Text += $"Pivot Shift: ({-_modelCenter.X}, {-_modelCenter.Y}, {-_modelCenter.Z})\r\n\r\n";
            // TEST

            int cnt = 1;

            foreach(Group group in this.modelData.Groups)
            {
                this.textBox1.Text += $"{group.Name} {cnt}\r\n";
                this.textBox1.Text += $"  Faces: {group.Faces.Count}\r\n";
                this.textBox1.Text += $"  V-Cnt: {group.Faces.Count * 3} \r\n";
                bool hasTexture = (group.Material?.DiffuseTextureMap != null);
                this.textBox1.Text += $"  Has texture: {(hasTexture ? "Yes" : "No")}\r\n\r\n";
                cnt++;
            }
        }

        public void doRender()
        {
            if (modelData == null || _renderInfo.Count == 0) return;


            _shaderHost.Use();
            Transformation transformCtrl = null;

            if (this.gameObj != null)
            {
                transformCtrl = this.gameObj.componentList.OfType<Transformation>().FirstOrDefault();
            }

            Matrix4 transformMatrix = transformCtrl._localTransform;
            Matrix4 translation = Matrix4.CreateTranslation(0f, 0f, -10f);
            Matrix4 finalMatrix = translation * transformMatrix;

            _shaderHost.SetMatrix4("transformation", finalMatrix);
            _shaderHost.SetMatrix4("projection", Form1.perspective);

            foreach (var groupInfo in _renderInfo)
            {
                GL.BindVertexArray(groupInfo.vaoTriangleUVHandle);
                
                if(groupInfo.textureHandle != 0)
                {
                    GL.ActiveTexture(TextureUnit.Texture0);
                    GL.BindTexture(TextureTarget.Texture2D, groupInfo.textureHandle);

                    // Pass to Shader
                    _shaderHost.SetInt("textureUnit", 0);
                    _shaderHost.SetBool("useTexture", true);
                }
                else
                {
                    // No texture, use Fallback color
                    _shaderHost.SetBool("useTexture", false);
                    _shaderHost.SetVector3("color", new Vector3(1, 0, 0));
                }

                GL.DrawArrays(PrimitiveType.Triangles, 0, groupInfo.triangleVertexCount);

                // Unbind texture
                GL.BindTexture(TextureTarget.Texture2D, 0);

                GL.BindVertexArray(groupInfo.vaoLineHandle);

                _shaderHost.SetBool("useTexture", false);
                _shaderHost.SetVector3("color", new Vector3(1, 1, 1));

                GL.LineWidth(2.0f);


                // Polygon offset
                GL.Enable(EnableCap.PolygonOffsetLine);
                GL.PolygonOffset(-1.0f, -1.0f);

                GL.DrawArrays(PrimitiveType.Lines, 0, groupInfo.lineVertexCount);

                GL.Disable(EnableCap.PolygonOffsetLine);
            }

            // cleanup
            GL.BindVertexArray(0);

        }
    }
}
