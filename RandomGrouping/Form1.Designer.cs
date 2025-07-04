namespace RandomGrouping
{
    partial class MainForm
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
            SeatsLayoutPanel = new FlowLayoutPanel();
            OutputTextBox = new TextBox();
            InputGroupCount = new TextBox();
            label1 = new Label();
            Btn_Pick = new Button();
            SuspendLayout();
            // 
            // SeatsLayoutPanel
            // 
            SeatsLayoutPanel.AutoScroll = true;
            SeatsLayoutPanel.FlowDirection = FlowDirection.TopDown;
            SeatsLayoutPanel.Location = new Point(12, 12);
            SeatsLayoutPanel.Name = "SeatsLayoutPanel";
            SeatsLayoutPanel.Size = new Size(215, 360);
            SeatsLayoutPanel.TabIndex = 2;
            SeatsLayoutPanel.WrapContents = false;
            // 
            // OutputTextBox
            // 
            OutputTextBox.Location = new Point(697, 12);
            OutputTextBox.Multiline = true;
            OutputTextBox.Name = "OutputTextBox";
            OutputTextBox.ReadOnly = true;
            OutputTextBox.Size = new Size(215, 360);
            OutputTextBox.TabIndex = 3;
            OutputTextBox.WordWrap = false;
            // 
            // InputGroupCount
            // 
            InputGroupCount.Location = new Point(591, 12);
            InputGroupCount.Name = "InputGroupCount";
            InputGroupCount.Size = new Size(100, 38);
            InputGroupCount.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(452, 15);
            label1.Name = "label1";
            label1.Size = new Size(133, 30);
            label1.TabIndex = 5;
            label1.Text = "抽出組數：";
            // 
            // Btn_Pick
            // 
            Btn_Pick.Location = new Point(275, 7);
            Btn_Pick.Name = "Btn_Pick";
            Btn_Pick.Size = new Size(150, 46);
            Btn_Pick.TabIndex = 6;
            Btn_Pick.Text = "抽出";
            Btn_Pick.UseVisualStyleBackColor = true;
            Btn_Pick.Click += Picking;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(14F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(924, 629);
            Controls.Add(Btn_Pick);
            Controls.Add(label1);
            Controls.Add(InputGroupCount);
            Controls.Add(OutputTextBox);
            Controls.Add(SeatsLayoutPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainForm";
            Text = "值日生隨機分組";
            FormClosing += OnFormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private FlowLayoutPanel SeatsLayoutPanel;
        private TextBox OutputTextBox;
        private TextBox InputGroupCount;
        private Label label1;
        private Button Btn_Pick;
    }
}
