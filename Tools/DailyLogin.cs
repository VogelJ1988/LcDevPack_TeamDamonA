using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LcDevPack_TeamDamonA.Tools
{
    public partial class DailyLogin2 : Form
    {
        public static Connection connection = new Connection();
        private readonly string Host = DailyLogin2.connection.ReadSettings("Host");
        private readonly string User = DailyLogin2.connection.ReadSettings("User");
        private readonly string Password = DailyLogin2.connection.ReadSettings("Password");
        private readonly string Database = DailyLogin2.connection.ReadSettings("Database");
        private readonly DatabaseHandle databaseHandle = new DatabaseHandle();
        private readonly ExportLodHandle exportLodHandle = new ExportLodHandle();
        //private static List<t_loginrewardnew> DailyLogin2= new List<t_loginrewardnew>();
        public string _ClientPath = LcDevPack_TeamDamonA.Tools.DailyLogin2.connection.ReadSettings("ClientPath");
        public DailyLogin2()
        {
            InitializeComponent();
            Fill_listbox();
        }
        void Fill_listbox()
        {
            string constring = ("datasource=" + Host + ";port=3306;username=" + User + ";password=" + Password + ";database=" + Database);
            string Query = ("SELECT * FROM t_loginrewardnew ORDER BY a_day ASC;"); ;
            //Fill_listbox();
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();

                while (myReader.Read())
                {
                    string SID = myReader.GetString("a_day");
                    string SID2 = myReader.GetString("a_itemidx");
                    listBox1.Items.Add(SID + " - " + SID2);
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                //conDataBase.Close();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = ("datasource=" + Host + ";port=3306;username=" + User + ";password=" + Password + ";database=" + Database);
            string Query = "select * FROM t_loginrewardnew WHERE a_day ='" + listBox1.Text + "';";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string sDay = myReader.GetInt32("a_day").ToString();
                    string sItem = myReader.GetString("a_itemidx");
                    string sPlus = myReader.GetInt32("a_plus").ToString();
                    string sFlag = myReader.GetInt32("a_flag").ToString();
                    string sCount = myReader.GetInt32("a_count").ToString();



                    Daytxt.Text = sDay;
                    ItemIDtxt.Text = sItem;
                    Plustxt.Text = sPlus;
                    Flagtxt.Text = sFlag;
                    Counttxt.Text = sCount;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conDataBase.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            databaseHandle.SendQueryMySql(Host, User, Password, Database, "UPDATE t_loginrewardnew SET " + "a_day = '" + Daytxt.Text + "', " + "a_itemidx = '" + ItemIDtxt.Text + "'," + "a_plus = '" + Plustxt + "', " + "a_flag = '" + Flagtxt.Text + "'," + "a_count = '" + Counttxt.Text + "' " + "WHERE a_day = '" + Daytxt.Text + "'");
            listBox1.Items.Clear();
            Fill_listbox();
            int selectedIndex = listBox1.SelectedIndex;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;
            databaseHandle.SendQueryMySql(Host, User, Password, Database, "DELETE FROM t_loginrewardnew WHERE a_day = '" + Daytxt.Text + "'");
            listBox1.Items.Clear();
            Fill_listbox();
            int num2 = (int)new CustomMessage("Deleted :O").ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            databaseHandle.SendQueryMySql(Host, User, Password, Database, "INSERT INTO t_loginrewardnew DEFAULT VALUES");
            listBox1.Items.Clear();
            Fill_listbox();
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            Daytxt.BackColor = Color.Lime;
            ItemIDtxt.BackColor = Color.Lime;
        }
    }
}
