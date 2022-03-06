using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LcDevPack_TeamDamonA.Tools
{

    public partial class Startitem : Form
    {

        public static Connection connection = new Connection();
        private readonly string Host = Startitem.connection.ReadSettings("Host");
        private readonly string User = Startitem.connection.ReadSettings("User");
        private readonly string Password = Startitem.connection.ReadSettings("Password");
        private readonly string Database = Startitem.connection.ReadSettings("Database");
        private readonly DatabaseHandle databaseHandle = new DatabaseHandle();
        private readonly ExportLodHandle exportLodHandle = new ExportLodHandle();
        public Startitem()
        {
            InitializeComponent();
            Fill_listbox();
            comboBox1.Items.AddRange(new object[9] //dethunter12 initialize the combo box values at startup 6/3/2019 
{
         "0 - Titain",
         "1 - Knight",
         "2 - Healer",
         "3 - Mage",
         "4 - Rogue",
         "5 - Sorcerer",
         "6 - Night Shadow",
         "7 - Ex-Rogue",
         "8 - Ex-Mage"

});
            comboBox2.Items.AddRange(new object[13]
      {

         
         "0 - Hood Slot",
         "1 - Shirt Slot",
         "2 - Weapon Slot",
         "3 - Pants Slot",
         "4 - Shield Slot",
         "5 - Gloves Slot",
         "6 - Boots Slot",
         "7 - Accesoire Slot",
         "8 - Accesoire Slot",
         "9 - Accesoire Slot",
         "10 - Pet Slot",
         "11 - Wing Slot",
         "-1 - None",
      });
            listBox1.SelectedIndex = 0;

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            classtxt.Text = GetIndexByComboBox(comboBox1.Text).ToString();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (weartxt.Text == "-1") 
            {
                weartxt.Text = GetIndexByComboBox(comboBox2.Text).ToString();
        } 
    }
        void Fill_listbox()
        {
            string constring = ("datasource=" + Host + ";port=3306;username=" + User + ";password=" + Password + ";database=" + Database);
            string Query = ("SELECT * FROM t_startitems ORDER BY a_index ASC;"); ;
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();

                while (myReader.Read())
                {
                    string SID = myReader.GetString("a_index");
                    string SID2 = myReader.GetString("a_name");
                    listBox1.Items.Add(SID + " - " + SID2);
                }
            }

            catch (Exception ex)

            {
                //conDataBase.Close();
            }

        }

        public int GetIndexByComboBox(string comboBox)
        {
            try
            {
                return Convert.ToInt32(comboBox.Split(' ')[0]);
            }
            catch
            {
                return 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            databaseHandle.SendQueryMySql(Host, User, Password, Database, "INSERT INTO t_startitems DEFAULT VALUES");
            listBox1.Items.Clear();
            Fill_listbox();
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            index.BackColor = Color.Lime;
            ItemName.BackColor = Color.Lime;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = ("datasource=" + Host + ";port=3306;username=" + User + ";password=" + Password + ";database=" + Database);
            string Query = "select * FROM t_startitems WHERE a_index ='" + listBox1.Text + "';";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string sID = myReader.GetInt32("a_index").ToString();
                    string sName = myReader.GetString("a_name");
                    string sItem = myReader.GetInt32("a_itemidx").ToString();
                    string sCount = myReader.GetInt32("a_itemcount").ToString();
                    string sPlus = myReader.GetInt32("a_plus").ToString();
                    string sClass = myReader.GetInt32("a_job").ToString();
                    comboBox1.SelectedIndex = Convert.ToInt32(sClass);
                    string sWear = myReader.GetInt32("a_wearpos").ToString();
                    comboBox2.SelectedIndex = Convert.ToInt32(sWear);


                    index.Text = sID;
                    ItemName.Text = sName;
                    Plus.Text = sPlus;
                    ItemID.Text = sItem;
                    Count.Text = sCount;
                    classtxt.Text = sClass;
                    weartxt.Text = sWear;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            {
                conDataBase.Close();
            }
        }

            private void button2_Click(object sender, EventArgs e)
        {
            databaseHandle.SendQueryMySql(Host, User, Password, Database, "UPDATE t_startitems SET " + "a_index = '" + index.Text + "', " + "a_itemidx = '" + ItemID.Text + "'," + "a_name = '" + ItemName.Text + "', " + "a_itemcount = '" + Count.Text + "'," + "a_job = '" + classtxt.Text + "', " + "a_wearpos = '" + weartxt.Text + "' , " + "a_Plus = '" + Plus.Text + "' "+ "WHERE a_index = '" + index.Text + "'");
            listBox1.Items.Clear();
            Fill_listbox();
            int selectedIndex = listBox1.SelectedIndex;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;
            databaseHandle.SendQueryMySql(Host, User, Password, Database, "DELETE FROM t_startitems WHERE a_index = '" + index.Text + "'");
            listBox1.Items.Clear();
            Fill_listbox();
            int num2 = (int)new CustomMessage("Deleted :O").ShowDialog();
        }
    } 
}