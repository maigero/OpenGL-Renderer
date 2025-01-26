namespace Übung
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
            glControl = new OpenTK.GLControl.GLControl();
            tableLayoutPanel1 = new TableLayoutPanel();
            sceneManager1 = new SceneManager(components);
            groupBoxGlobal = new GroupBox();
            checkBoxCycleColor = new CheckBox();
            button1 = new Button();
            numericUpDownFPS = new NumericUpDown();
            label1 = new Label();
            componentManager1 = new ComponentManager(components);
            toolStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBoxGlobal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownFPS).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.Bottom;
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1 });
            toolStrip1.Location = new Point(197, 425);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(441, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(38, 22);
            toolStripLabel1.Text = "FPS: 0";
            // 
            // glControl
            // 
            glControl.API = OpenTK.Windowing.Common.ContextAPI.OpenGL;
            glControl.APIVersion = new Version(3, 3, 0, 0);
            glControl.Dock = DockStyle.Fill;
            glControl.Flags = OpenTK.Windowing.Common.ContextFlags.Default;
            glControl.IsEventDriven = true;
            glControl.Location = new Point(197, 0);
            glControl.Name = "glControl";
            glControl.Profile = OpenTK.Windowing.Common.ContextProfile.Compatability;
            glControl.SharedContext = null;
            glControl.Size = new Size(441, 425);
            glControl.TabIndex = 3;
            glControl.Load += glControl1_Load_1;
            glControl.Paint += glControl1_Paint_1;
            glControl.Resize += glControl1_Resize_1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(sceneManager1, 0, 0);
            tableLayoutPanel1.Controls.Add(groupBoxGlobal, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Left;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(197, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // sceneManager1
            // 
            sceneManager1.AllowDrop = true;
            sceneManager1.ComponentManager = null;
            sceneManager1.Dock = DockStyle.Fill;
            sceneManager1.form = null;
            sceneManager1.Location = new Point(3, 3);
            sceneManager1.Name = "sceneManager1";
            sceneManager1.Size = new Size(191, 219);
            sceneManager1.TabIndex = 0;
            // 
            // groupBoxGlobal
            // 
            groupBoxGlobal.Controls.Add(checkBoxCycleColor);
            groupBoxGlobal.Controls.Add(button1);
            groupBoxGlobal.Controls.Add(numericUpDownFPS);
            groupBoxGlobal.Controls.Add(label1);
            groupBoxGlobal.Dock = DockStyle.Fill;
            groupBoxGlobal.Location = new Point(3, 228);
            groupBoxGlobal.Name = "groupBoxGlobal";
            groupBoxGlobal.Size = new Size(191, 219);
            groupBoxGlobal.TabIndex = 1;
            groupBoxGlobal.TabStop = false;
            groupBoxGlobal.Text = "global";
            // 
            // checkBoxCycleColor
            // 
            checkBoxCycleColor.AutoSize = true;
            checkBoxCycleColor.Location = new Point(13, 76);
            checkBoxCycleColor.Name = "checkBoxCycleColor";
            checkBoxCycleColor.Size = new Size(87, 19);
            checkBoxCycleColor.TabIndex = 3;
            checkBoxCycleColor.Text = "Cycle Color";
            checkBoxCycleColor.UseVisualStyleBackColor = true;
            checkBoxCycleColor.CheckedChanged += checkBoxCycleColor_CheckedChanged;
            // 
            // button1
            // 
            button1.Location = new Point(13, 110);
            button1.Name = "button1";
            button1.Size = new Size(99, 23);
            button1.TabIndex = 2;
            button1.Text = "Load Default";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // numericUpDownFPS
            // 
            numericUpDownFPS.Location = new Point(45, 31);
            numericUpDownFPS.Name = "numericUpDownFPS";
            numericUpDownFPS.Size = new Size(42, 23);
            numericUpDownFPS.TabIndex = 1;
            numericUpDownFPS.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 33);
            label1.Name = "label1";
            label1.Size = new Size(26, 15);
            label1.TabIndex = 0;
            label1.Text = "FPS";
            // 
            // componentManager1
            // 
            componentManager1.Dock = DockStyle.Right;
            componentManager1.Location = new Point(638, 0);
            componentManager1.Name = "componentManager1";
            componentManager1.Size = new Size(215, 450);
            componentManager1.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(853, 450);
            Controls.Add(glControl);
            Controls.Add(toolStrip1);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(componentManager1);
            Name = "Form1";
            Text = "My OpenGL App";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            groupBoxGlobal.ResumeLayout(false);
            groupBoxGlobal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownFPS).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStrip toolStrip1;
        private OpenTK.GLControl.GLControl glControl;
        private TableLayoutPanel tableLayoutPanel1;
        private SceneManager sceneManager1;
        private GroupBox groupBoxGlobal;
        private ToolStripLabel toolStripLabel1;
        private NumericUpDown numericUpDownFPS;
        private Label label1;
        private ComponentManager componentManager1;
        private Button button1;
        private CheckBox checkBoxCycleColor;
    }
}
