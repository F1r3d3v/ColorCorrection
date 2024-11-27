namespace GK1_ColorCorrection
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
            pbPreview = new PictureBox();
            tlpHistograms = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            groupBox1 = new GroupBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            groupBox2 = new GroupBox();
            flowLayoutPanel3 = new FlowLayoutPanel();
            bHistEqualization = new Button();
            HistStretching = new Button();
            flowLayoutPanel4 = new FlowLayoutPanel();
            label1 = new Label();
            nudStretchingThreshold = new NumericUpDown();
            flowLayoutPanel6 = new FlowLayoutPanel();
            bWhiteBalance = new Button();
            pWhiteReference = new Panel();
            flowLayoutPanel5 = new FlowLayoutPanel();
            bBlackBalance = new Button();
            pBlackReference = new Panel();
            bApplyBalance = new Button();
            bGreyscale = new Button();
            panel1 = new Panel();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pbPreview).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            groupBox2.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudStretchingThreshold).BeginInit();
            flowLayoutPanel6.SuspendLayout();
            flowLayoutPanel5.SuspendLayout();
            panel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pbPreview
            // 
            pbPreview.BorderStyle = BorderStyle.FixedSingle;
            pbPreview.Dock = DockStyle.Fill;
            pbPreview.Location = new Point(9, 8);
            pbPreview.Margin = new Padding(3, 2, 3, 2);
            pbPreview.Name = "pbPreview";
            pbPreview.Size = new Size(567, 486);
            pbPreview.SizeMode = PictureBoxSizeMode.Zoom;
            pbPreview.TabIndex = 0;
            pbPreview.TabStop = false;
            pbPreview.Click += pbPreview_Click;
            pbPreview.MouseLeave += pbPreview_MouseLeave;
            pbPreview.MouseMove += pbPreview_MouseMove;
            // 
            // tlpHistograms
            // 
            tlpHistograms.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlpHistograms.ColumnCount = 2;
            tlpHistograms.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpHistograms.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpHistograms.Dock = DockStyle.Fill;
            tlpHistograms.Location = new Point(9, 25);
            tlpHistograms.Margin = new Padding(3, 8, 3, 2);
            tlpHistograms.Name = "tlpHistograms";
            tlpHistograms.RowCount = 3;
            tlpHistograms.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tlpHistograms.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tlpHistograms.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tlpHistograms.Size = new Size(474, 316);
            tlpHistograms.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(groupBox1);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel2);
            flowLayoutPanel1.Dock = DockStyle.Right;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(585, 24);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(501, 502);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tlpHistograms);
            groupBox1.Location = new Point(0, 1);
            groupBox1.Margin = new Padding(0, 1, 0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(9);
            groupBox1.Size = new Size(492, 350);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Histograms";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel2.Controls.Add(groupBox2);
            flowLayoutPanel2.Location = new Point(0, 351);
            flowLayoutPanel2.Margin = new Padding(0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(492, 138);
            flowLayoutPanel2.TabIndex = 2;
            // 
            // groupBox2
            // 
            groupBox2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBox2.Controls.Add(flowLayoutPanel3);
            groupBox2.Location = new Point(0, 0);
            groupBox2.Margin = new Padding(0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(492, 138);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Color correction";
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.AutoSize = true;
            flowLayoutPanel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel3.Controls.Add(bHistEqualization);
            flowLayoutPanel3.Controls.Add(HistStretching);
            flowLayoutPanel3.Controls.Add(flowLayoutPanel4);
            flowLayoutPanel3.Controls.Add(flowLayoutPanel6);
            flowLayoutPanel3.Controls.Add(flowLayoutPanel5);
            flowLayoutPanel3.Controls.Add(bApplyBalance);
            flowLayoutPanel3.Controls.Add(bGreyscale);
            flowLayoutPanel3.Dock = DockStyle.Fill;
            flowLayoutPanel3.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel3.Location = new Point(3, 19);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(486, 116);
            flowLayoutPanel3.TabIndex = 0;
            // 
            // bHistEqualization
            // 
            bHistEqualization.Location = new Point(3, 3);
            bHistEqualization.Name = "bHistEqualization";
            bHistEqualization.Size = new Size(242, 23);
            bHistEqualization.TabIndex = 0;
            bHistEqualization.Text = "Histogram equalization";
            bHistEqualization.UseVisualStyleBackColor = true;
            bHistEqualization.Click += bHistEqualization_Click;
            // 
            // HistStretching
            // 
            HistStretching.Location = new Point(3, 32);
            HistStretching.Name = "HistStretching";
            HistStretching.Size = new Size(242, 23);
            HistStretching.TabIndex = 1;
            HistStretching.Text = "Histogram streching";
            HistStretching.UseVisualStyleBackColor = true;
            HistStretching.Click += HistStretching_Click;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel4.Controls.Add(label1);
            flowLayoutPanel4.Controls.Add(nudStretchingThreshold);
            flowLayoutPanel4.Location = new Point(0, 62);
            flowLayoutPanel4.Margin = new Padding(0, 4, 0, 0);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(252, 29);
            flowLayoutPanel4.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 3);
            label1.Margin = new Padding(3, 3, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(117, 15);
            label1.TabIndex = 7;
            label1.Text = "Stretching threshold:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // nudStretchingThreshold
            // 
            nudStretchingThreshold.DecimalPlaces = 2;
            nudStretchingThreshold.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nudStretchingThreshold.Location = new Point(123, 1);
            nudStretchingThreshold.Margin = new Padding(0, 1, 0, 0);
            nudStretchingThreshold.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            nudStretchingThreshold.Name = "nudStretchingThreshold";
            nudStretchingThreshold.Size = new Size(113, 23);
            nudStretchingThreshold.TabIndex = 6;
            nudStretchingThreshold.Value = new decimal(new int[] { 2, 0, 0, 131072 });
            // 
            // flowLayoutPanel6
            // 
            flowLayoutPanel6.AutoSize = true;
            flowLayoutPanel6.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel6.Controls.Add(bWhiteBalance);
            flowLayoutPanel6.Controls.Add(pWhiteReference);
            flowLayoutPanel6.Location = new Point(252, 0);
            flowLayoutPanel6.Margin = new Padding(0);
            flowLayoutPanel6.Name = "flowLayoutPanel6";
            flowLayoutPanel6.Size = new Size(229, 26);
            flowLayoutPanel6.TabIndex = 10;
            // 
            // bWhiteBalance
            // 
            bWhiteBalance.Location = new Point(3, 3);
            bWhiteBalance.Margin = new Padding(3, 3, 0, 0);
            bWhiteBalance.Name = "bWhiteBalance";
            bWhiteBalance.Size = new Size(201, 23);
            bWhiteBalance.TabIndex = 2;
            bWhiteBalance.Text = "White balance eyerdrop";
            bWhiteBalance.UseVisualStyleBackColor = true;
            bWhiteBalance.Click += bWhiteBalance_Click;
            // 
            // pWhiteReference
            // 
            pWhiteReference.Location = new Point(206, 4);
            pWhiteReference.Margin = new Padding(2, 4, 0, 0);
            pWhiteReference.Name = "pWhiteReference";
            pWhiteReference.Size = new Size(23, 20);
            pWhiteReference.TabIndex = 5;
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.AutoSize = true;
            flowLayoutPanel5.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel5.Controls.Add(bBlackBalance);
            flowLayoutPanel5.Controls.Add(pBlackReference);
            flowLayoutPanel5.Location = new Point(252, 29);
            flowLayoutPanel5.Margin = new Padding(0, 3, 0, 3);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Size = new Size(229, 26);
            flowLayoutPanel5.TabIndex = 9;
            // 
            // bBlackBalance
            // 
            bBlackBalance.Location = new Point(3, 3);
            bBlackBalance.Margin = new Padding(3, 3, 0, 0);
            bBlackBalance.Name = "bBlackBalance";
            bBlackBalance.Size = new Size(201, 23);
            bBlackBalance.TabIndex = 3;
            bBlackBalance.Text = "Black balance eyedrop";
            bBlackBalance.UseVisualStyleBackColor = true;
            bBlackBalance.Click += bBlackBalance_Click;
            // 
            // pBlackReference
            // 
            pBlackReference.Location = new Point(206, 4);
            pBlackReference.Margin = new Padding(2, 4, 0, 0);
            pBlackReference.Name = "pBlackReference";
            pBlackReference.Size = new Size(23, 20);
            pBlackReference.TabIndex = 4;
            // 
            // bApplyBalance
            // 
            bApplyBalance.Location = new Point(255, 61);
            bApplyBalance.Name = "bApplyBalance";
            bApplyBalance.Size = new Size(225, 23);
            bApplyBalance.TabIndex = 11;
            bApplyBalance.Text = "Apply balance correction";
            bApplyBalance.UseVisualStyleBackColor = true;
            bApplyBalance.Click += bApplyBalance_Click;
            // 
            // bGreyscale
            // 
            bGreyscale.Location = new Point(255, 90);
            bGreyscale.Name = "bGreyscale";
            bGreyscale.Size = new Size(225, 23);
            bGreyscale.TabIndex = 4;
            bGreyscale.Text = "Convert to grayscale";
            bGreyscale.UseVisualStyleBackColor = true;
            bGreyscale.Click += bGreyscale_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(pbPreview);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 24);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(9, 8, 9, 8);
            panel1.Size = new Size(585, 502);
            panel1.TabIndex = 3;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.Menu;
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1086, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(180, 22);
            openToolStripMenuItem.Text = "Open...";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(180, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(180, 22);
            saveAsToolStripMenuItem.Text = "Save As...";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1086, 526);
            Controls.Add(panel1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(1102, 565);
            Name = "Form1";
            Text = "Color correction";
            ((System.ComponentModel.ISupportInitialize)pbPreview).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudStretchingThreshold).EndInit();
            flowLayoutPanel6.ResumeLayout(false);
            flowLayoutPanel5.ResumeLayout(false);
            panel1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbPreview;
        private TableLayoutPanel tlpHistograms;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private Button bHistEqualization;
        private Button HistStretching;
        private Button bWhiteBalance;
        private Button bBlackBalance;
        private Button bGreyscale;
        private NumericUpDown nudStretchingThreshold;
        private Label label1;
        private GroupBox groupBox2;
        private FlowLayoutPanel flowLayoutPanel3;
        private FlowLayoutPanel flowLayoutPanel4;
        private GroupBox groupBox1;
        private FlowLayoutPanel flowLayoutPanel5;
        private Panel pBlackReference;
        private FlowLayoutPanel flowLayoutPanel6;
        private Panel pWhiteReference;
        private Button bApplyBalance;
    }
}
