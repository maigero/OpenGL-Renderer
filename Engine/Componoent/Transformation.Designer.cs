namespace OpenGL_App.Engine.Componoent
{
    partial class Transformation
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            nudTranslationZ = new NumericUpDown();
            nudTranslationY = new NumericUpDown();
            nudTranslationX = new NumericUpDown();
            groupBox2 = new GroupBox();
            nudScaleZ = new NumericUpDown();
            nudScaleY = new NumericUpDown();
            nudScaleX = new NumericUpDown();
            groupBox3 = new GroupBox();
            nudRotationZ = new NumericUpDown();
            nudRotationY = new NumericUpDown();
            nudRotationX = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudTranslationZ).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTranslationY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTranslationX).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudScaleZ).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudScaleY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudScaleX).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudRotationZ).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRotationY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRotationX).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(nudTranslationZ);
            groupBox1.Controls.Add(nudTranslationY);
            groupBox1.Controls.Add(nudTranslationX);
            groupBox1.Location = new Point(0, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(213, 53);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Translation";
            // 
            // nudTranslationZ
            // 
            nudTranslationZ.Location = new Point(160, 22);
            nudTranslationZ.Name = "nudTranslationZ";
            nudTranslationZ.Size = new Size(53, 23);
            nudTranslationZ.TabIndex = 2;
            nudTranslationZ.Tag = "translationZ";
            nudTranslationZ.ValueChanged += nudTransform_ValueChanged;
            // 
            // nudTranslationY
            // 
            nudTranslationY.Location = new Point(88, 22);
            nudTranslationY.Name = "nudTranslationY";
            nudTranslationY.Size = new Size(53, 23);
            nudTranslationY.TabIndex = 1;
            nudTranslationY.Tag = "translationY";
            nudTranslationY.ValueChanged += nudTransform_ValueChanged;
            // 
            // nudTranslationX
            // 
            nudTranslationX.Location = new Point(15, 22);
            nudTranslationX.Name = "nudTranslationX";
            nudTranslationX.Size = new Size(53, 23);
            nudTranslationX.TabIndex = 0;
            nudTranslationX.Tag = "translationX";
            nudTranslationX.ValueChanged += nudTransform_ValueChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(nudScaleZ);
            groupBox2.Controls.Add(nudScaleY);
            groupBox2.Controls.Add(nudScaleX);
            groupBox2.Location = new Point(0, 54);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(216, 52);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Scale";
            // 
            // nudScaleZ
            // 
            nudScaleZ.Location = new Point(163, 22);
            nudScaleZ.Name = "nudScaleZ";
            nudScaleZ.Size = new Size(54, 23);
            nudScaleZ.TabIndex = 2;
            nudScaleZ.Tag = "scaleZ";
            nudScaleZ.ValueChanged += nudTransform_ValueChanged;
            // 
            // nudScaleY
            // 
            nudScaleY.Location = new Point(90, 22);
            nudScaleY.Name = "nudScaleY";
            nudScaleY.Size = new Size(54, 23);
            nudScaleY.TabIndex = 1;
            nudScaleY.Tag = "scaleY";
            nudScaleY.ValueChanged += nudTransform_ValueChanged;
            // 
            // nudScaleX
            // 
            nudScaleX.Location = new Point(18, 22);
            nudScaleX.Name = "nudScaleX";
            nudScaleX.Size = new Size(53, 23);
            nudScaleX.TabIndex = 0;
            nudScaleX.Tag = "scaleX";
            nudScaleX.ValueChanged += nudTransform_ValueChanged;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(nudRotationZ);
            groupBox3.Controls.Add(nudRotationY);
            groupBox3.Controls.Add(nudRotationX);
            groupBox3.Location = new Point(0, 105);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(219, 54);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Rotation";
            // 
            // nudRotationZ
            // 
            nudRotationZ.Location = new Point(163, 22);
            nudRotationZ.Name = "nudRotationZ";
            nudRotationZ.Size = new Size(53, 23);
            nudRotationZ.TabIndex = 2;
            nudRotationZ.Tag = "rotationZ";
            nudRotationZ.ValueChanged += nudTransform_ValueChanged;
            // 
            // nudRotationY
            // 
            nudRotationY.Location = new Point(90, 22);
            nudRotationY.Name = "nudRotationY";
            nudRotationY.Size = new Size(54, 23);
            nudRotationY.TabIndex = 1;
            nudRotationY.Tag = "rotationY";
            nudRotationY.ValueChanged += nudTransform_ValueChanged;
            // 
            // nudRotationX
            // 
            nudRotationX.Location = new Point(18, 22);
            nudRotationX.Name = "nudRotationX";
            nudRotationX.Size = new Size(53, 23);
            nudRotationX.TabIndex = 0;
            nudRotationX.Tag = "rotationX";
            nudRotationX.ValueChanged += nudTransform_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 24);
            label1.Name = "label1";
            label1.Size = new Size(14, 15);
            label1.TabIndex = 3;
            label1.Text = "X";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(72, 24);
            label2.Name = "label2";
            label2.Size = new Size(14, 15);
            label2.TabIndex = 4;
            label2.Text = "Y";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(143, 24);
            label3.Name = "label3";
            label3.Size = new Size(14, 15);
            label3.TabIndex = 5;
            label3.Text = "Z";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 25);
            label4.Name = "label4";
            label4.Size = new Size(14, 15);
            label4.TabIndex = 3;
            label4.Text = "X";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(72, 26);
            label5.Name = "label5";
            label5.Size = new Size(14, 15);
            label5.TabIndex = 4;
            label5.Text = "Y";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(146, 25);
            label6.Name = "label6";
            label6.Size = new Size(14, 15);
            label6.TabIndex = 5;
            label6.Text = "Z";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1, 25);
            label7.Name = "label7";
            label7.Size = new Size(14, 15);
            label7.TabIndex = 3;
            label7.Text = "X";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(73, 26);
            label8.Name = "label8";
            label8.Size = new Size(14, 15);
            label8.TabIndex = 4;
            label8.Text = "Y";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(147, 24);
            label9.Name = "label9";
            label9.Size = new Size(14, 15);
            label9.TabIndex = 5;
            label9.Text = "Z";
            // 
            // Transformation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Transformation";
            Size = new Size(219, 162);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudTranslationZ).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTranslationY).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTranslationX).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudScaleZ).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudScaleY).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudScaleX).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudRotationZ).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRotationY).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRotationX).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private NumericUpDown nudTranslationZ;
        private NumericUpDown nudTranslationY;
        private NumericUpDown nudTranslationX;
        private GroupBox groupBox2;
        private NumericUpDown nudScaleZ;
        private NumericUpDown nudScaleY;
        private NumericUpDown nudScaleX;
        private GroupBox groupBox3;
        private NumericUpDown nudRotationZ;
        private NumericUpDown nudRotationY;
        private NumericUpDown nudRotationX;
        private Label label1;
        private Label label3;
        private Label label2;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label9;
        private Label label8;
        private Label label7;
    }
}
