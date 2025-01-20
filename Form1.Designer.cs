namespace OpenGL_App
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripLabel();
            tableLayoutPanel1 = new TableLayoutPanel();
            sceneManager = new Engine.Manager.SceneManager();
            FPSInput = new NumericUpDown();
            componentManager1 = new Engine.Manager.ComponentManager();
            glControl = new OpenTK.WinForms.GLControl();
            toolStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)FPSInput).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.Bottom;
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1 });
            toolStrip1.Location = new Point(0, 547);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1102, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(86, 22);
            toolStripLabel1.Text = "toolStripLabel1";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CausesValidation = false;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(sceneManager, 0, 0);
            tableLayoutPanel1.Controls.Add(FPSInput, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Left;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 59.07859F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40.92141F));
            tableLayoutPanel1.Size = new Size(218, 547);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // sceneManager
            // 
            sceneManager.AllowDrop = true;
            sceneManager.Dock = DockStyle.Fill;
            sceneManager.Location = new Point(3, 2);
            sceneManager.Margin = new Padding(3, 2, 3, 2);
            sceneManager.Name = "sceneManager";
            sceneManager.Size = new Size(212, 319);
            sceneManager.TabIndex = 0;
            // 
            // FPSInput
            // 
            FPSInput.Location = new Point(2, 325);
            FPSInput.Margin = new Padding(2, 2, 2, 2);
            FPSInput.Name = "FPSInput";
            FPSInput.Size = new Size(126, 23);
            FPSInput.TabIndex = 1;
            FPSInput.Value = new decimal(new int[] { 5, 0, 0, 0 });
            FPSInput.ValueChanged += FPSInput_ValueChanged;
            // 
            // componentManager1
            // 
            componentManager1.Dock = DockStyle.Right;
            componentManager1.Location = new Point(868, 0);
            componentManager1.Margin = new Padding(3, 2, 3, 2);
            componentManager1.Name = "componentManager1";
            componentManager1.Size = new Size(234, 547);
            componentManager1.TabIndex = 2;
            // 
            // glControl
            // 
            glControl.API = OpenTK.Windowing.Common.ContextAPI.OpenGL;
            glControl.APIVersion = new Version(3, 3, 0, 0);
            glControl.BackColor = SystemColors.Control;
            glControl.Dock = DockStyle.Fill;
            glControl.Flags = OpenTK.Windowing.Common.ContextFlags.Default;
            glControl.IsEventDriven = true;
            glControl.Location = new Point(218, 0);
            glControl.Margin = new Padding(3, 2, 3, 2);
            glControl.Name = "glControl";
            glControl.Profile = OpenTK.Windowing.Common.ContextProfile.Compatability;
            glControl.Size = new Size(650, 547);
            glControl.TabIndex = 3;
            glControl.Text = "Viewport";
            glControl.Load += glControl2_Load;
            glControl.Paint += glControl2_Paint;
            glControl.Resize += glControl2_Resize;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1102, 572);
            Controls.Add(glControl);
            Controls.Add(componentManager1);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(toolStrip1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)FPSInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private TableLayoutPanel tableLayoutPanel1;
        private OpenTK.WinForms.GLControl glControl1;
        private Engine.Manager.ComponentManager componentManager1;
        private Engine.Manager.SceneManager sceneManager;
        private OpenTK.WinForms.GLControl glControl;
        private NumericUpDown FPSInput;
    }
}