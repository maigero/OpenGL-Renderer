using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
//using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK.Mathematics;


namespace OpenGL_App.Engine.Componoent
{
    public partial class Transformation : UserControl
    {
        private Vector3 _translation = Vector3.Zero;
        private Vector3 _scale = Vector3.Zero;
        private Vector3 _rotation = Vector3.Zero;

        public Matrix4 _localTransform = Matrix4.Identity;
        // TEST
        public Vector3 PivotShift = Vector3.Zero;
        // TEST

        public Transformation()
        {
            InitializeComponent();

            //  Translation 
            nudTranslationX.Minimum = -100m;
            nudTranslationX.Maximum = 100m;
            nudTranslationX.DecimalPlaces = 2;
            nudTranslationX.Increment = 0.1m;

            nudTranslationY.Minimum = -100m;
            nudTranslationY.Maximum = 100m;
            nudTranslationY.DecimalPlaces = 2;
            nudTranslationY.Increment = 0.1m;

            nudTranslationZ.Minimum = -100m;
            nudTranslationZ.Maximum = 100m;
            nudTranslationZ.DecimalPlaces = 2;
            nudTranslationZ.Increment = 0.1m;

            //  Rotation 
            nudRotationX.Minimum = -360m;
            nudRotationX.Maximum = 360m;
            nudRotationX.DecimalPlaces = 2;
            nudRotationX.Increment = 1m;

            nudRotationY.Minimum = -360m;
            nudRotationY.Maximum = 360m;
            nudRotationY.DecimalPlaces = 2;
            nudRotationY.Increment = 1m;

            nudRotationZ.Minimum = -360m;
            nudRotationZ.Maximum = 360m;
            nudRotationZ.DecimalPlaces = 2;
            nudRotationZ.Increment = 1m;

            //  Scale
            nudScaleX.Minimum = 0.001m;
            nudScaleX.Maximum = 100m;
            nudScaleX.DecimalPlaces = 3;
            nudScaleX.Increment = 0.001m;
            nudScaleX.Value = 0.1m;

            nudScaleY.Minimum = 0.001m;
            nudScaleY.Maximum = 100m;
            nudScaleY.DecimalPlaces = 3;
            nudScaleY.Increment = 0.001m;
            nudScaleY.Value = 0.1m;

            nudScaleZ.Minimum = 0.001m;
            nudScaleZ.Maximum = 100m;
            nudScaleZ.DecimalPlaces = 3;
            nudScaleZ.Increment = 0.001m;
            nudScaleZ.Value = 0.1m;

            _scale = new Vector3(0.1f, 0.1f, 0.1f);
            RecalcLocalTransform();

        }


        private void nudTransform_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            if (nud == null) return;

            switch (nud.Tag as string)
            {
                case "translationX":
                    _translation.X = (float)nud.Value;
                    break;
                case "translationY":
                    _translation.Y = (float)nud.Value;
                    break;
                case "translationZ":
                    _translation.Z = (float)nud.Value;
                    break;

                case "scaleX":
                    _scale.X = (float)nud.Value;
                    break;
                case "scaleY":
                    _scale.Y = (float)nud.Value;
                    break;
                case "scaleZ":
                    _scale.Z = (float)nud.Value;
                    break;

                case "rotationX":
                    _rotation.X = (float)nud.Value;
                    break;
                case "rotationY":
                    _rotation.Y = (float)nud.Value;
                    break;
                case "rotationZ":
                    _rotation.Z = (float)nud.Value;
                    break;
            }

            RecalcLocalTransform();
        }

        private void RecalcLocalTransform()
        {
            float rx = MathHelper.DegreesToRadians(_rotation.X);
            float ry = MathHelper.DegreesToRadians(_rotation.Y);
            float rz = MathHelper.DegreesToRadians(_rotation.Z);

            Matrix4 rotX = Matrix4.CreateRotationX(rx);
            Matrix4 rotY = Matrix4.CreateRotationY(ry);
            Matrix4 rotZ = Matrix4.CreateRotationZ(rz);

            Matrix4 transMat = Matrix4.CreateTranslation(_translation);
            Matrix4 scaleMat = Matrix4.CreateScale(_scale);


            // TEST


            Matrix4 pivotShift = Matrix4.CreateTranslation(-PivotShift);
            
            //TEST


            //_localTransform = pivotShift * rotX * rotY * rotZ * scaleMat * transMat;
            //_localTransform = scaleMat * rotX * rotY * rotZ * transMat;
            _localTransform = pivotShift * scaleMat *rotX * rotY * rotZ * transMat;

        }
    }
}
