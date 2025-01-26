namespace Übung.engine.component
{
    partial class BasicInformation
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
            textBoxName = new TextBox();
            SuspendLayout();
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(4, 3);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(203, 23);
            textBoxName.TabIndex = 0;
            textBoxName.TextChanged += textBoxName_TextChanged;
            // 
            // BasicInformation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(textBoxName);
            Name = "BasicInformation";
            Size = new Size(211, 29);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxName;
    }
}
