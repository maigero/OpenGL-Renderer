namespace OpenGL_App.Engine.Componoent
{
    partial class Transformation
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            numericUpDown1 = new NumericUpDown();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            numericUpDown2 = new NumericUpDown();
            numericUpDown3 = new NumericUpDown();
            numericUpDown4 = new NumericUpDown();
            numericUpDown5 = new NumericUpDown();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            numericUpDown6 = new NumericUpDown();
            numericUpDown7 = new NumericUpDown();
            numericUpDown8 = new NumericUpDown();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            numericUpDown9 = new NumericUpDown();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown9).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(3, 5);
            label1.Name = "label1";
            label1.Size = new Size(121, 15);
            label1.TabIndex = 0;
            label1.Text = "Transformation Data";
            // 
            // numericUpDown1
            // 
            numericUpDown1.DecimalPlaces = 1;
            numericUpDown1.Location = new Point(19, 42);
            numericUpDown1.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(50, 23);
            numericUpDown1.TabIndex = 1;
            numericUpDown1.Tag = "scale_x";
            numericUpDown1.ValueChanged += onTranslationChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 44);
            label2.Name = "label2";
            label2.Size = new Size(17, 15);
            label2.TabIndex = 2;
            label2.Text = "X:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(70, 44);
            label3.Name = "label3";
            label3.Size = new Size(17, 15);
            label3.TabIndex = 4;
            label3.Text = "Y:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(136, 44);
            label4.Name = "label4";
            label4.Size = new Size(17, 15);
            label4.TabIndex = 6;
            label4.Text = "Z:";
            // 
            // numericUpDown2
            // 
            numericUpDown2.DecimalPlaces = 1;
            numericUpDown2.Location = new Point(86, 42);
            numericUpDown2.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown2.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(50, 23);
            numericUpDown2.TabIndex = 7;
            numericUpDown2.Tag = "scale_y";
            numericUpDown2.ValueChanged += onTranslationChanged;
            // 
            // numericUpDown3
            // 
            numericUpDown3.DecimalPlaces = 1;
            numericUpDown3.Location = new Point(152, 42);
            numericUpDown3.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown3.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(50, 23);
            numericUpDown3.TabIndex = 8;
            numericUpDown3.Tag = "scale_z";
            numericUpDown3.ValueChanged += onTranslationChanged;
            // 
            // numericUpDown4
            // 
            numericUpDown4.Location = new Point(152, 107);
            numericUpDown4.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(50, 23);
            numericUpDown4.TabIndex = 14;
            numericUpDown4.Tag = "rotate_z";
            numericUpDown4.ValueChanged += onTranslationChanged;
            // 
            // numericUpDown5
            // 
            numericUpDown5.Location = new Point(86, 107);
            numericUpDown5.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            numericUpDown5.Name = "numericUpDown5";
            numericUpDown5.Size = new Size(50, 23);
            numericUpDown5.TabIndex = 13;
            numericUpDown5.Tag = "rotate_y";
            numericUpDown5.ValueChanged += onTranslationChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(136, 109);
            label5.Name = "label5";
            label5.Size = new Size(17, 15);
            label5.TabIndex = 12;
            label5.Text = "Z:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(70, 109);
            label6.Name = "label6";
            label6.Size = new Size(17, 15);
            label6.TabIndex = 11;
            label6.Text = "Y:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(4, 109);
            label7.Name = "label7";
            label7.Size = new Size(17, 15);
            label7.TabIndex = 10;
            label7.Text = "X:";
            // 
            // numericUpDown6
            // 
            numericUpDown6.Location = new Point(19, 107);
            numericUpDown6.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            numericUpDown6.Name = "numericUpDown6";
            numericUpDown6.Size = new Size(50, 23);
            numericUpDown6.TabIndex = 9;
            numericUpDown6.Tag = "rotate_x";
            numericUpDown6.ValueChanged += onTranslationChanged;
            // 
            // numericUpDown7
            // 
            numericUpDown7.DecimalPlaces = 1;
            numericUpDown7.Location = new Point(152, 172);
            numericUpDown7.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown7.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            numericUpDown7.Name = "numericUpDown7";
            numericUpDown7.Size = new Size(50, 23);
            numericUpDown7.TabIndex = 20;
            numericUpDown7.Tag = "translate_z";
            numericUpDown7.ValueChanged += onTranslationChanged;
            // 
            // numericUpDown8
            // 
            numericUpDown8.DecimalPlaces = 1;
            numericUpDown8.Location = new Point(86, 172);
            numericUpDown8.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown8.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            numericUpDown8.Name = "numericUpDown8";
            numericUpDown8.Size = new Size(50, 23);
            numericUpDown8.TabIndex = 19;
            numericUpDown8.Tag = "translate_y";
            numericUpDown8.ValueChanged += onTranslationChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(136, 174);
            label8.Name = "label8";
            label8.Size = new Size(17, 15);
            label8.TabIndex = 18;
            label8.Text = "Z:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(70, 174);
            label9.Name = "label9";
            label9.Size = new Size(17, 15);
            label9.TabIndex = 17;
            label9.Text = "Y:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(4, 174);
            label10.Name = "label10";
            label10.Size = new Size(17, 15);
            label10.TabIndex = 16;
            label10.Text = "X:";
            // 
            // numericUpDown9
            // 
            numericUpDown9.DecimalPlaces = 1;
            numericUpDown9.Location = new Point(19, 172);
            numericUpDown9.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown9.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            numericUpDown9.Name = "numericUpDown9";
            numericUpDown9.Size = new Size(50, 23);
            numericUpDown9.TabIndex = 15;
            numericUpDown9.Tag = "translate_x";
            numericUpDown9.ValueChanged += onTranslationChanged;
            // 
            // groupBox1
            // 
            groupBox1.Location = new Point(3, 23);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(205, 51);
            groupBox1.TabIndex = 24;
            groupBox1.TabStop = false;
            groupBox1.Text = "Scale";
            // 
            // groupBox2
            // 
            groupBox2.Location = new Point(3, 89);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(205, 51);
            groupBox2.TabIndex = 25;
            groupBox2.TabStop = false;
            groupBox2.Text = "Rotation";
            // 
            // groupBox3
            // 
            groupBox3.Location = new Point(3, 153);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(205, 51);
            groupBox3.TabIndex = 26;
            groupBox3.TabStop = false;
            groupBox3.Text = "Translation";
            // 
            // Transformation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(numericUpDown7);
            Controls.Add(numericUpDown8);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(numericUpDown9);
            Controls.Add(numericUpDown4);
            Controls.Add(numericUpDown5);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(numericUpDown6);
            Controls.Add(numericUpDown3);
            Controls.Add(numericUpDown2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(numericUpDown1);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox3);
            Name = "Transformation";
            Size = new Size(211, 210);
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown7).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown8).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown9).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private NumericUpDown numericUpDown1;
        private Label label2;
        private Label label3;
        private Label label4;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown4;
        private NumericUpDown numericUpDown5;
        private Label label5;
        private Label label6;
        private Label label7;
        private NumericUpDown numericUpDown6;
        private NumericUpDown numericUpDown7;
        private NumericUpDown numericUpDown8;
        private Label label8;
        private Label label9;
        private Label label10;
        private NumericUpDown numericUpDown9;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
    }
}
