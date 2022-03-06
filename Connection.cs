// Decompiled with JetBrains decompiler
// Type: LcDevPack_TeamDamonA.Connection
// Assembly: LcDevPack_TeamDamonA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6B9BC8BF-B510-4945-A515-04135CC0F4A4
// Assembly location: C:\Users\NTServer\Desktop\LcDevPack_TeamDamonA\LcDevPack_TeamDamonA\LcDevPack_TeamDamonA.exe

using System.IO;
using System.Windows.Forms;

namespace LcDevPack_TeamDamonA
{
    public class Connection
    {
        public string ReadSettings(string var)
        {
            if (!File.Exists("Config/Settings.cfg"))
            {
                int num = (int)MessageBox.Show("Cannot Found, SettingsFile is created now.");

                string[] contents = new string[10]
                {
          "## Main",
          "Episode=EP4",
          "ClientPath=",
          "## MYSQL",
          "SQL_HOST=127.0.0.1",
          "SQL_USER=root",
          "SQL_PASSWORD=",
          "SQL_DATABASE=2015_data",
          "Language=", //dethunter12 add
          "SQL_DB_DATABASE="
                };

                string path = Directory.GetCurrentDirectory() + "\\Config";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                File.WriteAllLines(path + "\\Settings.cfg", contents);
            }
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string str6 = "";
            string str7 = ""; //dethunter12 add
#pragma warning disable CS0219 // The variable 'str11' is assigned but its value is never used
            string str11 = ""; //dethunter12 add
#pragma warning restore CS0219 // The variable 'str11' is assigned but its value is never used
            string str12 = ""; //dethunter12 add
            string str13 = ""; //dethunter12 add

            TextReader textReader = (TextReader)new StreamReader("Config/Settings.cfg");
            string str9 = "";
            while ((str7 = textReader.ReadLine()) != null)
            {
                if (!str7.Contains("#") && (uint)str7.Length > 0U)
                {
                    string[] strArray = str7.Split('=');
                    foreach (string str8 in strArray)
                    {
                        if (strArray[0] == "SQL_HOST")
                            str1 = strArray[1];
                        if (strArray[0] == "SQL_USER")
                            str2 = strArray[1];
                        if (strArray[0] == "SQL_PASSWORD")
                            str3 = strArray[1];
                        if (strArray[0] == "SQL_DATABASE")
                            str4 = strArray[1];
                        if (strArray[0] == "Episode")
                            str5 = strArray[1];
                        if (strArray[0] == "ClientPath")
                            str6 = strArray[1];
                        if (strArray[0] == "Language") //dethunter12 test read
                            str9 = strArray[1]; //dethunter12 test
                        if (strArray[0] == "SQL_DB_DATABASE")
                            str13 = strArray[1];
                    }
                }
            }

            textReader.Close();

            if (var == "Host")
                return str1;
            if (var == "User")
                return str2;
            if (var == "Password")
                return str3;
            if (var == "Database")
                return str4 + (str9 == "THA" ? ";CharSet=tis620" : "");
            if (var == "Episode")
                return str5;
            if (var == "ClientPath")
                return str6;
            if (var == "Language") //dethunter12 test
                return str9; // dethunter12 test
            return str12;
#pragma warning disable CS0162 // Unreachable code detected
            if (var == "DB_Database")
#pragma warning restore CS0162 // Unreachable code detected
                return str13;
            return "";

        }
    }
}
