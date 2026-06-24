namespace SymbolClassificator
{
    partial class SymbolClassificator
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
            pictureBox1 = new PictureBox();
            toolStrip1 = new ToolStrip();
            toolStripSeparator6 = new ToolStripSeparator();
            submitButton = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            clearButton = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripSeparator3 = new ToolStripSeparator();
            drawButton = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            eraseButton = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            predictButton = new ToolStripButton();
            toolStripSeparator7 = new ToolStripSeparator();
            toolStripTextBox1 = new ToolStripTextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(12, 28);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(280, 280);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripSeparator6, submitButton, toolStripSeparator1, clearButton, toolStripSeparator2, toolStripSeparator3, drawButton, toolStripSeparator4, eraseButton, toolStripSeparator5, predictButton, toolStripSeparator7, toolStripTextBox1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(326, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(6, 25);
            // 
            // submitButton
            // 
            submitButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            submitButton.Image = Properties.Resources.submit_button_icon;
            submitButton.ImageTransparentColor = Color.Magenta;
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(23, 22);
            submitButton.Text = "submitButton";
            submitButton.Click += submitButton_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // clearButton
            // 
            clearButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            clearButton.Image = Properties.Resources.ClearButtonIcon;
            clearButton.ImageTransparentColor = Color.Magenta;
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(23, 22);
            clearButton.Text = "clearButton";
            clearButton.Click += clearButton_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 25);
            // 
            // drawButton
            // 
            drawButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            drawButton.Image = Properties.Resources.DrawButtonIcon;
            drawButton.ImageTransparentColor = Color.Magenta;
            drawButton.Name = "drawButton";
            drawButton.Size = new Size(23, 22);
            drawButton.Text = "drawButton";
            drawButton.Click += drawButton_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 25);
            // 
            // eraseButton
            // 
            eraseButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            eraseButton.Image = Properties.Resources.EraseButtonIcon;
            eraseButton.ImageTransparentColor = Color.Magenta;
            eraseButton.Name = "eraseButton";
            eraseButton.Size = new Size(23, 22);
            eraseButton.Text = "eraseButton";
            eraseButton.Click += eraseButton_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 25);
            // 
            // predictButton
            // 
            predictButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            predictButton.Image = Properties.Resources.PredictButtonIcon;
            predictButton.ImageTransparentColor = Color.Magenta;
            predictButton.Name = "predictButton";
            predictButton.Size = new Size(23, 22);
            predictButton.Text = "predictButton";
            predictButton.Click += predictButton_Click;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(6, 25);
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.Size = new Size(100, 25);
            toolStripTextBox1.Click += toolStripTextBox1_Click;
            // 
            // SymbolClassificator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(326, 326);
            Controls.Add(toolStrip1);
            Controls.Add(pictureBox1);
            Name = "SymbolClassificator";
            Text = "SymbolClassificator";
            Load += SymbolClassificator_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private ToolStrip toolStrip1;
        private ToolStripButton submitButton;
        private ToolStripButton clearButton;
        private ToolStripButton predictButton;
        private ToolStripButton drawButton;
        private ToolStripButton eraseButton;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripTextBox toolStripTextBox1;
        private ToolStripSeparator toolStripSeparator7;
    }
}
