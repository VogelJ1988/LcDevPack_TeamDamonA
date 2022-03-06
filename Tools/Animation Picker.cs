﻿using System;
using System.Windows.Forms;

namespace LcDevPack_TeamDamonA.Tools
{
    public partial class Animation_Picker : Form
    {
        public String Animation;
        public Animation_Picker(string FileName, string Animation)
        {
            InitializeComponent();
            Text = Animation;
            foreach (cAnimation cAnimation in AnimReader.ReadFile(FileName).Animation)
                LbAnimationList.Items.Add(cAnimation.AnimeName);
        }

        private void LbAnimationList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Animation = LbAnimationList.Text;
            //DialogResult = DialogResult.OK;
        }
    }
}
