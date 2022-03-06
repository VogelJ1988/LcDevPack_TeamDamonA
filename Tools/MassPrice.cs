using System;
using System.Windows.Forms;

namespace LcDevPack_TeamDamonA.Tools
{
    public partial class MassPrice : Form
    {
        //5/30/2020
        private readonly string Host = ItemEditor2.connection.ReadSettings("Host");
        private readonly string User = ItemEditor2.connection.ReadSettings("User");
        private readonly string Password = ItemEditor2.connection.ReadSettings("Password");
        private readonly string Database = ItemEditor2.connection.ReadSettings("Database");
        private readonly string language = ItemEditor2.connection.ReadSettings("Language");
        private readonly DatabaseHandle databaseHandle = new DatabaseHandle();
        public MassPrice()
        {
            InitializeComponent();
        }

        private void BtnUpdateSelectedRange_Click(object sender, EventArgs e)
        {
            if (tbRange1.Text == "" || tbRange2.Text == "")
            {
                int num2 = (int)new CustomMessage("Insert a value in ranges!").ShowDialog();
            }
            else
            {
                databaseHandle.SendQueryMySql(Host, User, Password, Database, "UPDATE t_item SET  a_price  = '" + TbPrice.Text + "'" + "WHERE a_index BETWEEN '" + tbRange1.Text + "'" + " " + "AND'" + tbRange2.Text + "'" + ";");
                int num2 = (int)new CustomMessage("Done!").ShowDialog();
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
