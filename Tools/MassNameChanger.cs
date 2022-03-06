﻿using System;
using System.Windows.Forms;

namespace LcDevPack_TeamDamonA.Tools //dethunter12 10/3/2019 add
{
    public partial class MassNameChanger : Form
    {
        //dethunter12 add
        //to initialize a paramater in which to send data to db.
        private readonly string Host = ItemEditor2.connection.ReadSettings("Host");
        private readonly string User = ItemEditor2.connection.ReadSettings("User");
        private readonly string Password = ItemEditor2.connection.ReadSettings("Password");
        private readonly string Database = ItemEditor2.connection.ReadSettings("Database");
        private readonly string language = ItemEditor2.connection.ReadSettings("Language");
        public string namee; //dethunter12 stringfrom lang modify
        public string aname = ""; //dehtunter12 add
        private readonly DatabaseHandle databaseHandle = new DatabaseHandle();

        public string StringFromLanguage() //dethunter12 10/3/2019
        {

            if (language == "GER")
            {
                namee = "a_name_ger";
                return namee;

            }
            else if (language == "POL")
            {
                namee = "a_name_pld";
                return namee;

            }
            else if (language == "BRA")
            {
                namee = "a_name_brz";
                return namee;
            }
            else if (language == "RUS")
            {
                namee = "a_name_rus";
                return namee;
            }
            else if (language == "FRA")
            {
                namee = "a_name_frc";
                return namee;
            }
            else if (language == "ESP")
            {
                namee = "a_name_spn";
                return namee;
            }
            else if (language == "MEX")
            {
                namee = "a_name_mex";
                return namee;
            }
            else if (language == "THA")
            {
                namee = "a_name_thai";
                return namee;
            }
            else if (language == "ITA")
            {
                namee = "a_name_ita";
                return namee;
            }
            else if (language == "USA")
            {
                namee = "a_name_usa";
                return namee;
            }
            else
            {
                return null;
            }
        }
        public MassNameChanger()
        {
            InitializeComponent();
        }

        private void BtnUpdateSelectedRange_Click(object sender, EventArgs e) //dethunter12 10/3/2019
        {
            namee = StringFromLanguage();
            if (cbAddBefore.Checked == true || cbRemoveBefore.Checked == true)
            {
                if (tbItemName.Text != "" && tbRange1.Text != "" && tbRange2.Text != "" && cbRemoveBefore.Checked == true) //done
                {
                    databaseHandle.SendQueryMySql(Host, User, Password, Database, "UPDATE t_item SET " + namee + "= REPLACE(" + namee + ",'" + tbItemName.Text + "','" + "') " + "WHERE a_index BETWEEN '" + tbRange1.Text + "'" + " " + "AND'" + tbRange2.Text + "'" + ";");
                    int num2 = (int)new CustomMessage("DONE!").ShowDialog();
                    Close(); //dethunter12 adjust 12/23/2019
                }

                else if (tbItemName.Text != "" && tbRange1.Text != "" && tbRange2.Text != "" && cbAddBefore.Checked == true) //done
                {
                    databaseHandle.SendQueryMySql(Host, User, Password, Database, "UPDATE t_item SET " + namee + "= CONCAT ('" + tbItemName.Text + "'," + namee + ")" + "WHERE a_index BETWEEN '" + tbRange1.Text + "'" + " " + "AND'" + tbRange2.Text + "'" + ";");
                    int num2 = (int)new CustomMessage("DONE!").ShowDialog();
                    MassNameChanger massNameChanger = new MassNameChanger();
                    massNameChanger.Close();

                }

                else if (tbItemName.Text != "" && tbRange1.Text != "" && tbRange2.Text.Equals(""))
                {
                    int num2 = (int)new CustomMessage("Please Enter Range 2 Value").ShowDialog();
                }
                else if (tbItemName.Text != "" && tbRange1.Text.Equals("") && tbRange2.Text != "")
                {
                    int num2 = (int)new CustomMessage("Please Enter Range 1 Value").ShowDialog();
                }
                else if (tbItemName.Text.Equals("") && tbRange1.Text != "" && tbRange2.Text != "")
                {
                    int num2 = (int)new CustomMessage("Please Select a Name ").ShowDialog();
                }
            }
            else
            {
                int num2 = (int)new CustomMessage("Check one of the boxes").ShowDialog();
            }
        }

        private void PbSelectID1_Click(object sender, EventArgs e)
        {
            ItemPicker itemPicker = new ItemPicker();
            if (itemPicker.ShowDialog() != DialogResult.OK)
                return;
            tbRange1.Text = Convert.ToString(itemPicker.ItemIndex);
        }

        private void PbSelectID2_Click(object sender, EventArgs e)
        {
            ItemPicker itemPicker = new ItemPicker();
            if (itemPicker.ShowDialog() != DialogResult.OK)
                return;
            tbRange2.Text = Convert.ToString(itemPicker.ItemIndex);

        }
    }
}
