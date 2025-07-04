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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(14F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(924, 629);
            Controls.Add(SeatsLayoutPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainForm";
            Text = "值日生隨機分組";
            Load += Form1_Load;
            FormClosing += OnFormClosing;
            ResumeLayout(false);
        }

        #endregion
        private FlowLayoutPanel SeatsLayoutPanel;
    }
}
