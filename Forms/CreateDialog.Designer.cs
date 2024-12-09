namespace GK1_ColorCorrection
{
    partial class CreateDialog
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
            button1 = new Button();
            numericUpDown1 = new NumericUpDown();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label1 = new Label();
            flowLayoutPanel3 = new FlowLayoutPanel();
            numericUpDown2 = new NumericUpDown();
            label2 = new Label();
            flowLayoutPanel4 = new FlowLayoutPanel();
            numericUpDown3 = new NumericUpDown();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Dock = DockStyle.Top;
            button1.Location = new Point(9, 102);
            button1.Margin = new Padding(4, 10, 4, 0);
            button1.Name = "button1";
            button1.Size = new Size(214, 23);
            button1.TabIndex = 0;
            button1.Text = "Set";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(0, 0);
            numericUpDown1.Margin = new Padding(0);
            numericUpDown1.Maximum = new decimal(new int[] { -1, -1, -1, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(143, 23);
            numericUpDown1.TabIndex = 1;
            numericUpDown1.KeyDown += numericUpDown1_KeyDown;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(flowLayoutPanel2);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel3);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel4);
            flowLayoutPanel1.Controls.Add(button1);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(5);
            flowLayoutPanel1.Size = new Size(540, 194);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel2.Controls.Add(numericUpDown1);
            flowLayoutPanel2.Controls.Add(label1);
            flowLayoutPanel2.Location = new Point(8, 8);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(188, 23);
            flowLayoutPanel2.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(146, 4);
            label1.Margin = new Padding(3, 4, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 3;
            label1.Text = "Width";
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.AutoSize = true;
            flowLayoutPanel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel3.Controls.Add(numericUpDown2);
            flowLayoutPanel3.Controls.Add(label2);
            flowLayoutPanel3.Location = new Point(8, 37);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(192, 23);
            flowLayoutPanel3.TabIndex = 3;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(0, 0);
            numericUpDown2.Margin = new Padding(0);
            numericUpDown2.Maximum = new decimal(new int[] { -1, -1, -1, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(143, 23);
            numericUpDown2.TabIndex = 1;
            numericUpDown2.KeyDown += numericUpDown1_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(146, 4);
            label2.Margin = new Padding(3, 4, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 3;
            label2.Text = "Height";
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.AutoSize = true;
            flowLayoutPanel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel4.Controls.Add(numericUpDown3);
            flowLayoutPanel4.Controls.Add(label3);
            flowLayoutPanel4.Location = new Point(8, 66);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(216, 23);
            flowLayoutPanel4.TabIndex = 4;
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(0, 0);
            numericUpDown3.Margin = new Padding(0);
            numericUpDown3.Maximum = new decimal(new int[] { -1, -1, -1, 0 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(143, 23);
            numericUpDown3.TabIndex = 1;
            numericUpDown3.KeyDown += numericUpDown1_KeyDown;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(146, 4);
            label3.Margin = new Padding(3, 4, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 3;
            label3.Text = "Pattern size";
            // 
            // CreateDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(540, 194);
            Controls.Add(flowLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreateDialog";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Create Test Image";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private NumericUpDown numericUpDown1;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel3;
        private NumericUpDown numericUpDown2;
        private Label label2;
        private FlowLayoutPanel flowLayoutPanel4;
        private NumericUpDown numericUpDown3;
        private Label label3;
    }
}