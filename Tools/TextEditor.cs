using System;
using System.IO;
using System.Windows.Forms;

namespace LcDevPack_TeamDamonA.Tools
{
    public partial class TextEditor : Form
    {
#pragma warning disable CS0169 // The field 'TextEditor.FileName' is never used
        private readonly string FileName;
#pragma warning restore CS0169 // The field 'TextEditor.FileName' is never used
        public TextEditor(string FileName)
        {
            InitializeComponent();
#pragma warning disable CS1717 // Assignment made to same variable; did you mean to assign something else?
            FileName = FileName;
#pragma warning restore CS1717 // Assignment made to same variable; did you mean to assign something else?
            if (!File.Exists(FileName))
                return;
            RTbSMC.Text = File.ReadAllText(FileName);
            RTbSMC.Select(0, 0);
            Text = FileName;
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close(); //close lol
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            File.WriteAllText(Text, RTbSMC.Text); //dethunter12 adjust
            int num4 = (int)new CustomMessage("Saved").ShowDialog();
        }
    }
}
