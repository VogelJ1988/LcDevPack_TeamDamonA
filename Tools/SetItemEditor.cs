using System;
using System.Windows.Forms;

namespace LcDevPack_TeamDamonA.Tools
{
    public partial class SetItemEditor : Form
    {
        public SetItemEditor()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                tbEnable.Text = "1";
            else
                tbEnable.Text = "0";
        }
    }
}
