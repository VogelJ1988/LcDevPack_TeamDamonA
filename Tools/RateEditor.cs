using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LcDevPack_TeamDamonA.Tools
{
    public partial class RateEditor : Form
    {
        public static Connection connection = new Connection();
        private string Host = Startitem.connection.ReadSettings("Host");
        private string User = Startitem.connection.ReadSettings("User");
        private string Password = Startitem.connection.ReadSettings("Password");
        private string Database = Startitem.connection.ReadSettings("Database");
        public RateEditor()
        {
            InitializeComponent();
        }
    }
}
