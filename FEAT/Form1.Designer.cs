
namespace FEAT
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.autoExtractToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batchCompressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAfterProcessingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arcOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enablePaddingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bytesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bytesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bytesToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.bytesToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.bytesToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.bytesToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.bytesToolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.compressionOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lZ10CompressionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lZ11ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lZ13ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportDaeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportSMDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableBinDecomplingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.creditsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(447, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.goToolStripMenuItem,
            this.creditsToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(38, 22);
            this.toolStripDropDownButton1.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // goToolStripMenuItem
            // 
            this.goToolStripMenuItem.Name = "goToolStripMenuItem";
            this.goToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.goToolStripMenuItem.Text = "Go";
            this.goToolStripMenuItem.Click += new System.EventHandler(this.goToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoExtractToolStripMenuItem,
            this.batchCompressToolStripMenuItem,
            this.deleteAfterProcessingToolStripMenuItem,
            this.arcOptionsToolStripMenuItem,
            this.compressionOptionsToolStripMenuItem,
            this.modelOptionsToolStripMenuItem,
            this.enableBinDecomplingToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(62, 22);
            this.toolStripDropDownButton2.Text = "Options";
            // 
            // autoExtractToolStripMenuItem
            // 
            this.autoExtractToolStripMenuItem.Checked = true;
            this.autoExtractToolStripMenuItem.CheckOnClick = true;
            this.autoExtractToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoExtractToolStripMenuItem.Name = "autoExtractToolStripMenuItem";
            this.autoExtractToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.autoExtractToolStripMenuItem.Text = "Auto Extract";
            // 
            // batchCompressToolStripMenuItem
            // 
            this.batchCompressToolStripMenuItem.CheckOnClick = true;
            this.batchCompressToolStripMenuItem.Name = "batchCompressToolStripMenuItem";
            this.batchCompressToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.batchCompressToolStripMenuItem.Text = "Batch Compress";
            // 
            // deleteAfterProcessingToolStripMenuItem
            // 
            this.deleteAfterProcessingToolStripMenuItem.CheckOnClick = true;
            this.deleteAfterProcessingToolStripMenuItem.Name = "deleteAfterProcessingToolStripMenuItem";
            this.deleteAfterProcessingToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.deleteAfterProcessingToolStripMenuItem.Text = "Delete After Processing";
            // 
            // arcOptionsToolStripMenuItem
            // 
            this.arcOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enablePaddingToolStripMenuItem,
            this.bytesToolStripMenuItem,
            this.bytesToolStripMenuItem1,
            this.bytesToolStripMenuItem2,
            this.bytesToolStripMenuItem3,
            this.bytesToolStripMenuItem4,
            this.bytesToolStripMenuItem5,
            this.bytesToolStripMenuItem6});
            this.arcOptionsToolStripMenuItem.Name = "arcOptionsToolStripMenuItem";
            this.arcOptionsToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.arcOptionsToolStripMenuItem.Text = "Arc Options";
            // 
            // enablePaddingToolStripMenuItem
            // 
            this.enablePaddingToolStripMenuItem.Checked = true;
            this.enablePaddingToolStripMenuItem.CheckOnClick = true;
            this.enablePaddingToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enablePaddingToolStripMenuItem.Name = "enablePaddingToolStripMenuItem";
            this.enablePaddingToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.enablePaddingToolStripMenuItem.Text = "Enable Padding";
            // 
            // bytesToolStripMenuItem
            // 
            this.bytesToolStripMenuItem.CheckOnClick = true;
            this.bytesToolStripMenuItem.Name = "bytesToolStripMenuItem";
            this.bytesToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.bytesToolStripMenuItem.Text = "0 Bytes";
            // 
            // bytesToolStripMenuItem1
            // 
            this.bytesToolStripMenuItem1.CheckOnClick = true;
            this.bytesToolStripMenuItem1.Name = "bytesToolStripMenuItem1";
            this.bytesToolStripMenuItem1.Size = new System.Drawing.Size(156, 22);
            this.bytesToolStripMenuItem1.Text = "4 Bytes";
            // 
            // bytesToolStripMenuItem2
            // 
            this.bytesToolStripMenuItem2.CheckOnClick = true;
            this.bytesToolStripMenuItem2.Name = "bytesToolStripMenuItem2";
            this.bytesToolStripMenuItem2.Size = new System.Drawing.Size(156, 22);
            this.bytesToolStripMenuItem2.Text = "8 Bytes";
            // 
            // bytesToolStripMenuItem3
            // 
            this.bytesToolStripMenuItem3.CheckOnClick = true;
            this.bytesToolStripMenuItem3.Name = "bytesToolStripMenuItem3";
            this.bytesToolStripMenuItem3.Size = new System.Drawing.Size(156, 22);
            this.bytesToolStripMenuItem3.Text = "16 Bytes";
            // 
            // bytesToolStripMenuItem4
            // 
            this.bytesToolStripMenuItem4.CheckOnClick = true;
            this.bytesToolStripMenuItem4.Name = "bytesToolStripMenuItem4";
            this.bytesToolStripMenuItem4.Size = new System.Drawing.Size(156, 22);
            this.bytesToolStripMenuItem4.Text = "32 Bytes";
            // 
            // bytesToolStripMenuItem5
            // 
            this.bytesToolStripMenuItem5.CheckOnClick = true;
            this.bytesToolStripMenuItem5.Name = "bytesToolStripMenuItem5";
            this.bytesToolStripMenuItem5.Size = new System.Drawing.Size(156, 22);
            this.bytesToolStripMenuItem5.Text = "64 Bytes";
            // 
            // bytesToolStripMenuItem6
            // 
            this.bytesToolStripMenuItem6.Checked = true;
            this.bytesToolStripMenuItem6.CheckOnClick = true;
            this.bytesToolStripMenuItem6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bytesToolStripMenuItem6.Name = "bytesToolStripMenuItem6";
            this.bytesToolStripMenuItem6.Size = new System.Drawing.Size(156, 22);
            this.bytesToolStripMenuItem6.Text = "128 Bytes";
            // 
            // compressionOptionsToolStripMenuItem
            // 
            this.compressionOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lZ10CompressionToolStripMenuItem,
            this.lZ11ToolStripMenuItem,
            this.lZ13ToolStripMenuItem});
            this.compressionOptionsToolStripMenuItem.Name = "compressionOptionsToolStripMenuItem";
            this.compressionOptionsToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.compressionOptionsToolStripMenuItem.Text = "Compression Options";
            // 
            // lZ10CompressionToolStripMenuItem
            // 
            this.lZ10CompressionToolStripMenuItem.CheckOnClick = true;
            this.lZ10CompressionToolStripMenuItem.Name = "lZ10CompressionToolStripMenuItem";
            this.lZ10CompressionToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.lZ10CompressionToolStripMenuItem.Text = "LZ10 ";
            // 
            // lZ11ToolStripMenuItem
            // 
            this.lZ11ToolStripMenuItem.CheckOnClick = true;
            this.lZ11ToolStripMenuItem.Name = "lZ11ToolStripMenuItem";
            this.lZ11ToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.lZ11ToolStripMenuItem.Text = "LZ11 ";
            // 
            // lZ13ToolStripMenuItem
            // 
            this.lZ13ToolStripMenuItem.Checked = true;
            this.lZ13ToolStripMenuItem.CheckOnClick = true;
            this.lZ13ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lZ13ToolStripMenuItem.Name = "lZ13ToolStripMenuItem";
            this.lZ13ToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.lZ13ToolStripMenuItem.Text = "LZ13";
            // 
            // modelOptionsToolStripMenuItem
            // 
            this.modelOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportDaeToolStripMenuItem,
            this.exportSMDToolStripMenuItem});
            this.modelOptionsToolStripMenuItem.Name = "modelOptionsToolStripMenuItem";
            this.modelOptionsToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.modelOptionsToolStripMenuItem.Text = "Model Options";
            // 
            // exportDaeToolStripMenuItem
            // 
            this.exportDaeToolStripMenuItem.CheckOnClick = true;
            this.exportDaeToolStripMenuItem.Name = "exportDaeToolStripMenuItem";
            this.exportDaeToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.exportDaeToolStripMenuItem.Text = "Export Dae";
            // 
            // exportSMDToolStripMenuItem
            // 
            this.exportSMDToolStripMenuItem.CheckOnClick = true;
            this.exportSMDToolStripMenuItem.Name = "exportSMDToolStripMenuItem";
            this.exportSMDToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.exportSMDToolStripMenuItem.Text = "Export SMD";
            // 
            // enableBinDecomplingToolStripMenuItem
            // 
            this.enableBinDecomplingToolStripMenuItem.CheckOnClick = true;
            this.enableBinDecomplingToolStripMenuItem.Name = "enableBinDecomplingToolStripMenuItem";
            this.enableBinDecomplingToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.enableBinDecomplingToolStripMenuItem.Text = "Enable Bin Decompiling";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 22);
            this.toolStripButton1.Text = "Help";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.Location = new System.Drawing.Point(8, 31);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(432, 309);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "Open a file, or Drag/Drop several! Click this box to clear its text.";
            this.richTextBox1.Click += new System.EventHandler(this.richTextBox1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(155, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(284, 20);
            this.textBox1.TabIndex = 2;
            // 
            // creditsToolStripMenuItem
            // 
            this.creditsToolStripMenuItem.Name = "creditsToolStripMenuItem";
            this.creditsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.creditsToolStripMenuItem.Text = "Credits";
            this.creditsToolStripMenuItem.Click += new System.EventHandler(this.creditsToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 347);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "FEAT - Fire Emblem Archive Tool";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem autoExtractToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem batchCompressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAfterProcessingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arcOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enablePaddingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bytesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bytesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bytesToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem bytesToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem bytesToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem bytesToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem bytesToolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem compressionOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lZ10CompressionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lZ11ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lZ13ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modelOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportDaeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportSMDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableBinDecomplingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creditsToolStripMenuItem;
    }
}

