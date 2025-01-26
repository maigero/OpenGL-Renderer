namespace Übung.engine.component
{
    partial class MeshRenderer
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
            textBox1 = new TextBox();
            buttonLoadMesh = new Button();
            openFileDialog1 = new OpenFileDialog();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(3, 32);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(203, 220);
            textBox1.TabIndex = 0;
            // 
            // buttonLoadMesh
            // 
            buttonLoadMesh.Location = new Point(3, 3);
            buttonLoadMesh.Name = "buttonLoadMesh";
            buttonLoadMesh.Size = new Size(203, 23);
            buttonLoadMesh.TabIndex = 1;
            buttonLoadMesh.Text = "Load Mesh Data";
            buttonLoadMesh.UseVisualStyleBackColor = true;
            buttonLoadMesh.Click += buttonLoadMesh_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // MeshRenderer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(buttonLoadMesh);
            Controls.Add(textBox1);
            Name = "MeshRenderer";
            Size = new Size(211, 259);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button buttonLoadMesh;
        private OpenFileDialog openFileDialog1;
    }
}
