using System.Windows.Forms;

namespace LcDevPack_TeamDamonA.Tools
{
    public partial class MobMassEdit : Form
    {
        private readonly string Host = MobEditor.connection.ReadSettings("Host");
        private readonly string User = MobEditor.connection.ReadSettings("User");
        private readonly string Password = MobEditor.connection.ReadSettings("Password");
        private readonly string Database = MobEditor.connection.ReadSettings("Database");
        private readonly DatabaseHandle databaseHandle = new DatabaseHandle();
        public MobMassEdit()
        {
            InitializeComponent();
        }
    }
}
