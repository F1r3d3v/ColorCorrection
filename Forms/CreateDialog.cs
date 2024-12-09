using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK1_ColorCorrection
{
    public partial class CreateDialog : Form
    {
        public int ImageWidth
        {
            get => (int)numericUpDown1.Value;
            set => numericUpDown1.Value = value;
        }

        public int ImageHeight
        {
            get => (int)numericUpDown2.Value;
            set => numericUpDown2.Value = value;
        }

        public int PatternSize
        {
            get => (int)numericUpDown3.Value;
            set => numericUpDown3.Value = value;
        }

        public CreateDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
