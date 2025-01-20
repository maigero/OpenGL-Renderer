using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using Timer = System.Windows.Forms.Timer;

namespace OpenGL_App
{
    public partial class Form1 : Form
    {
        private Timer _timer;

        public static Matrix4 perspective = Matrix4.Identity;

        public Form1()
        {
            InitializeComponent();
            this.InitTimer();
        }

        private void InitTimer()
        {
            this._timer = new Timer();
            this._timer.Tick += (sender, e) =>
            {
                glControl.Invalidate();
            };
            this._timer.Interval = 1000;
            this._timer.Start();
        }

        private void glControl2_Resize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, glControl.ClientSize.Width, glControl.ClientSize.Height);

            float aspect = (float)glControl.ClientSize.Width / (float)glControl.ClientSize.Height;

            Form1.perspective = Matrix4.CreatePerspectiveFieldOfView(
                    MathHelper.DegreesToRadians(45), // 45-degree field of view
                    aspect, // Aspect ratio
                    0.1f, // Near clipping plane
                    100.0f // Far clipping plane
                );

        }

        private void glControl2_Load(object sender, EventArgs e)
        {
            GL.ClearColor(Color4.MidnightBlue);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);
        }

        private void glControl2_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);                // Clear any prior drawing.
            GL.ClearColor(Color4.MidnightBlue);

            this.sceneManager.doRenderScene();

            glControl.SwapBuffers();    // Display the result.
        }

        private void FPSInput_ValueChanged(object sender, EventArgs e)
        {
            this._timer.Interval = (int)(1/(sender as NumericUpDown).Value) * 1000;
        }
    }
}