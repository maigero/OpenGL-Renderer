using OpenTK.GLControl;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System.Windows.Forms;
using Übung.engine;

namespace Übung
{
    public partial class Form1 : Form
    {
        private GameObject gameObject;
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        const int FPSDefault = 30; //Standardwert: 30 FPS
        const int IntervalDefault = 1000 / FPSDefault;

        Color4 colorOriginal = Color4.MidnightBlue;
        Color4 color;
        float deltaCol = 0.05f;
        bool cycleColor = false;

        public static Matrix4 perspective = Matrix4.Identity;

        public Form1()
        {
            InitializeComponent();

            // glControl.Profile = OpenTK.Windowing.Common.ContextProfile.Any;

            //glControl1.Load += GlControl1_Load;
            //glControl1.Resize += GlControl1_Resize;
            //glControl1.Paint += GlControl1_Paint;

            numericUpDownFPS.Minimum = 1; // Minimum 1 FPS
            numericUpDownFPS.Maximum = 60; // Maximum 60 FPS
            numericUpDownFPS.Value = FPSDefault;

            timer.Interval = IntervalDefault;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            glControl.Invalidate();
        }

        private void glControl1_Load_1_OLD(object sender, EventArgs e)
        {
            color = colorOriginal;
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(color);
            glControl.SwapBuffers();
        }

        private void glControl1_Load_1(object sender, EventArgs e)
        {
            GL.ClearColor(Color4.MidnightBlue);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);

            GL.FrontFace(FrontFaceDirection.Ccw);
            GL.DepthFunc(DepthFunction.Less);
        }

        void CycleColor()
        {
            if (color.B <= 0f)
            {
                color = colorOriginal;
            }

            if (color.R <= 0f)
            {
                if (color.G <= 0f)
                {
                    if (color.B <= 0f)
                    {
                    }
                    else color.B -= deltaCol;
                }
                else color.G -= deltaCol;
            }
            else color.R -= deltaCol;
        }

        private void glControl1_Paint_1_OLD(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(color);
            // CycleColor();

            GL.LoadIdentity();
            //GL.Translate(0, 0, -10); // translate the camera in -z

            sceneManager1.doRenderScene();

            glControl.SwapBuffers();
        }
        private void glControl1_Paint_1(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);                // Clear any prior drawing.
            if (cycleColor)
            { 
                GL.ClearColor(color);
                CycleColor();
            }
            else
                GL.ClearColor(Color4.MidnightBlue);

            this.sceneManager1.doRenderScene();

            glControl.SwapBuffers();    // Display the result.
        }

        private void glControl1_Resize_1(object sender, EventArgs e)
        {
            if (glControl.Width == 0 || glControl.Height == 0)
                return;

            // set the correct viewport parameters
            GL.Viewport(0, 0, glControl.ClientSize.Width, glControl.ClientSize.Height);

            float aspect = (float)glControl.Width / (float)glControl.Height;
            // Erstellen der Perspektivmatrix
            perspective = Matrix4.CreatePerspectiveFieldOfView(
                MathHelper.DegreesToRadians(45.0f), // Sichtfeld
                aspect, // Seitenverhältnis
                0.1f, // Nah-Clipping-Ebene
                100.0f // Fern-Clipping-Ebene
            );

            // Setzen der Perspektivmatrix in OpenGL
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.LoadMatrix(ref perspective);
            // Rückkehr zur ModelView-Matrix
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            toolStripLabel1.Text = $"FPS:{numericUpDownFPS.Value}";
            int interval = 1000 / (int)numericUpDownFPS.Value; // 1000/framerate= interval in ms
            if (interval <= 100)
                timer.Interval = (int)interval;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = "C:\\FH\\Git-Repos\\WEHR-hainschitz-stefan-WS2024-3DEngines\\assets\\models\\D6X912IHRDR9EHZ164U20M55S.obj";
            sceneManager1.LoadModel(path);
        }

        private void checkBoxCycleColor_CheckedChanged(object sender, EventArgs e)
        {
            cycleColor = checkBoxCycleColor.Checked;
        }
    }
}
