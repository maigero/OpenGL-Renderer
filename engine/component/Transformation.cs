using Übung.engine.Interfaces;
using OpenTK.Mathematics;
using Übung.engine;
using System.Diagnostics.Metrics;

namespace OpenGL_App.Engine.Componoent
{
    public struct TRANSFORMATION_INFO
    {
        public float x;
        public float y;
        public float z;

        public override string ToString()
        {
            return $"{x}, {y}, {z}";
        }
    }

    public partial class Transformation : UserControl, IHasTransformationInfo
    {
        public GameObject gameObject;

        private TRANSFORMATION_INFO _translate_info;
        private TRANSFORMATION_INFO _scale_info;
        private TRANSFORMATION_INFO _rotation_info; //rotation in degrees

        private Matrix4 rXMat = Matrix4.Identity;
        private Matrix4 rYMat = Matrix4.Identity;
        private Matrix4 rZMat = Matrix4.Identity;

        private Matrix4 localTransform = Matrix4.Identity;

        public Matrix4 transformationData
        {
            get
            {
                return localTransform;
            }
        }

        public Transformation()
        {
            InitializeComponent();
        }

        public Transformation(GameObject gameObject)
        {
            InitializeComponent();
            this.gameObject = gameObject;

            this._scale_info.x = 1;
            this._scale_info.y = 1;
            this._scale_info.z = 1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.gameObject.Text = (sender as TextBox).Text;
        }

        private void onTranslationChanged(object sender, EventArgs e)
        {
            NumericUpDown obj = sender as NumericUpDown;
            switch (obj.Tag)
            {
                case "rotate_x":
                    _rotation_info.x = numericFormat(obj, 360);
                    break;
                case "rotate_y":
                    _rotation_info.y = numericFormat(obj, 360);
                    break;
                case "rotate_z":
                    _rotation_info.z = numericFormat(obj, 360);
                    break;
                case "scale_x":
                    this._scale_info.x = (float)obj.Value;
                    break;
                case "scale_y":
                    this._scale_info.y = (float)obj.Value;
                    break;
                case "scale_z":
                    this._scale_info.z = (float)obj.Value;
                    break;
                case "translate_x":
                    this._translate_info.x = (float)obj.Value;
                    break;
                case "translate_y":
                    this._translate_info.y = (float)obj.Value;
                    break;
                case "translate_z":
                    this._translate_info.z = (float)obj.Value;
                    break;
            }
            this.updatelocalTransform();
        }

        public float numericFormat(NumericUpDown ctrl, float switchValue)
        {
            float value = (float)ctrl.Value;
            if (Math.Abs(value) >= switchValue)
            {
                value = 0;
                ctrl.Value = 0;
                return value;
            }

            return value;
        }

        public void updatelocalTransform()
        {
            Matrix4 trMat = Matrix4.CreateTranslation(this._translate_info.x, this._translate_info.y, this._translate_info.z);
            Matrix4 scaleMat = Matrix4.CreateScale(this._scale_info.x, this._scale_info.y, this._scale_info.z);

            this.rXMat = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(_rotation_info.x));
            this.rYMat = Matrix4.CreateRotationY(MathHelper.DegreesToRadians(_rotation_info.y));
            this.rZMat = Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(_rotation_info.z));

            this.localTransform = rXMat * rYMat * rZMat * trMat * scaleMat;
        }

        public override string ToString()
        {
            return $"R({_rotation_info.ToString()});T({_translate_info.ToString()});S({_scale_info.ToString()}";
        }
    }
}
