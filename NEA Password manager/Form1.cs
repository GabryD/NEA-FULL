using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace NEA_Password_manager
{
    public partial class Form1 : MaterialForm
    {
        DataTable Passwords = new DataTable();

        public Form1()
        {
            InitializeComponent();
            
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
           
        }
        public string Passlist = @"Passwordlist.xml";
        public string account1 { get; set; }
        public string acc { get; set; }
        public bool log { get; set; }
        string crypt = "f0xle@rn";
        public void Reload(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Passlist); 

            string usernameToCheck = Properties.Settings.Default.Account;

            string xpathQuery = $"//User[text()='{usernameToCheck}']";

            XmlNode usernameNode = xmlDoc.SelectSingleNode(xpathQuery);

            if (usernameNode != null)
            {
                
            }
            else
            {
                FirstPass();
                Firstschool();
                Firstwork();
            }
            
            XDocument doc = XDocument.Load(Passlist);
            string targetValue;
            if (account1 == null)
            {
                account1 = Properties.Settings.Default.Account;
                targetValue = Properties.Settings.Default.Account;
            }
            else
            {
                targetValue = Properties.Settings.Default.Account;
            }
            var filteredRows = GetRowsWithSpecificValue(doc, targetValue);
            bool hasdata = Firsttime(doc, targetValue);
            startup already = new startup();
            already.AU = hasdata;

            if (hasdata != true)
            {
                startup a = new startup();
                a.Show();
                this.Close();
            }
            else
            {

                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("User");
                    foreach (var row in filteredRows)
                    {


                    }
                    Form form = new Form();
                    DataGridView dataGridView = new DataGridView();
                    dataGridView.DataSource = dataTable;
                    form.Controls.Add(dataGridView);
                    var ch = GetRowsWithSpecificValue(doc, account1);
                    DataSet ds = new DataSet();
                    ds.ReadXml(Passlist);
                    string coulmn = "User";
                    foreach (var row in filteredRows)
                    {

                    }
                    var filteredrows = ds.Tables[0].AsEnumerable()
                        .Where(row => row.Field<string>(coulmn) == account1)
                        .Where(row => row.Field<string>("Location") == "Favourite")
                        .CopyToDataTable();
                    dataGridView1.DataSource = filteredrows;
                    string hide = "User";
                    if (dataGridView1.Columns.Contains(hide))
                    {
                        dataGridView1.Columns["Location"].Visible = false;
                        dataGridView1.Columns[hide].Visible = false;
                        dataGridView1.Columns["id"].Visible = false;
                    }
                

            }

            if (Tabs.TabPages.Count == 2)
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("User");
                foreach (var row in filteredRows)
                {


                }
                Form form = new Form();
                DataGridView dataGridView1 = new DataGridView();
                dataGridView1.DataSource = dataTable;
                form.Controls.Add(dataGridView1);
                var ch = GetRowsWithSpecificValue(doc, account1);
                DataSet ds = new DataSet();
                ds.ReadXml(Passlist);
                string coulmn = "User";
                foreach (var row in filteredRows)
                {

                }
                var filteredrows = ds.Tables[0].AsEnumerable()
                .Where(row => row.Field<string>(coulmn) == account1)
                .CopyToDataTable();
                passall.DataSource = filteredrows;
                string hide = "User";
                if (passall.Columns.Contains(hide))
                {
                    passall.Columns["Location"].Visible = false;
                    passall.Columns[hide].Visible = false;
                    passall.Columns["id"].Visible = false;
                }
            }

            List<string> list = new List<string>();
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (item.Cells.Count >= 2 &&
                    item.Cells[2].Value != null)
                {
                    list.Add(item.Cells[2].Value.ToString());
                }
            }
            int score = 0;
            int count = dataGridView1.Rows.Count;
            foreach (var v in list)
            {

                string x = DecryptBase64(v.ToString());
                if (x.Length >= 8 && x.Length <= 11)
                {
                    score = score + 1;
                }
                if (x.Length >= 12 && x.Length <= 15)
                {
                    score = score + 2;
                }
                if (x.Length >= 16)
                {
                    score = score + 3;
                }
                if (Regex.IsMatch(x, @"[a-z]"))
                {
                    score++;
                }
                if (Regex.IsMatch(x, @"[A-Z]"))
                {
                    score++;
                }
                if (Regex.IsMatch(x, @"\d"))
                {
                    score++;
                }
                if (Regex.IsMatch(x, @"[^\w]"))
                {
                    score++;
                }
            }
            strength.Value = score / count;
            List<string> list1 = new List<string>();
            foreach (DataGridViewRow item1 in passall.Rows)
            {
                if (item1.Cells.Count >= 2 &&
                    item1.Cells[2].Value != null) 
                {
                    list.Add(item1.Cells[2].Value.ToString());
                }
            }
            int score1 = 0;
            int count1 = passall.Rows.Count;
            foreach (var v in list)
            {

                string x = DecryptBase64(v.ToString());
                if (x.Length >= 8 && x.Length <= 11)
                {
                    score1 = score1 + 1;
                }
                if (x.Length >= 12 && x.Length <= 15)
                {
                    score1 = score1 + 2;
                }
                if (x.Length >= 16)
                {
                    score1 = score1 + 3;
                }
                if (Regex.IsMatch(x, @"[a-z]"))
                {
                    score1++;
                }
                if (Regex.IsMatch(x, @"[A-Z]"))
                {
                    score1++;
                }
                if (Regex.IsMatch(x, @"\d"))
                {
                    score1++;
                }
                if (Regex.IsMatch(x, @"[^\w]"))
                {
                    score1++;
                }
            }
            School();
            Work();
            top();
            folder();
            Customfo();
        }
        public void folder()
        {
            string name = "";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"CustomFolder");
            XmlNode phoneNode = xmlDoc.SelectSingleNode($"CustomFolder/Email[text()='{Properties.Settings.Default.Account}']/following-sibling::Folder");
            name = phoneNode != null ? phoneNode.InnerText : string.Empty;
            Tabs.TabPages[2].Text = name;

        }
        public void Customfo()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("User");
            Form form = new Form();
            DataGridView dataGridView1 = new DataGridView();
            dataGridView1.DataSource = dataTable;
            form.Controls.Add(dataGridView1);
            DataSet ds = new DataSet();
            ds.ReadXml(@"Passwordlist.xml");
            string coulmn = "User";
            var filteredrows = ds.Tables[0].AsEnumerable()
            .Where(row => row.Field<string>(coulmn) == account1)
            .Where(row => row.Field<string>("Location") == "Custom")
            .CopyToDataTable();
            CustomView.DataSource = filteredrows;
            string hide = "User";
            if (CustomView.Columns.Contains(hide))
            {
                CustomView.Columns["Location"].Visible = false;
                CustomView.Columns[hide].Visible = false;
                CustomView.Columns["id"].Visible = false;
            }
            
        }
        public void FirstPass()
        {
            string firstpass = "";
            byte[] data = UTF8Encoding.UTF8.GetBytes("This is your first pass");
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(crypt));
                using (TripleDESCryptoServiceProvider tripdes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripdes.CreateEncryptor();

                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    firstpass = Convert.ToBase64String(results, 0, results.Length);
                }
            }
            string xmlFilePath = @"Passwordlist.xml";
            XmlDocument dc = new XmlDocument();
            dc.Load(xmlFilePath);

            int maxId = 0;
            XmlNodeList idNodes = dc.SelectNodes("//Passwords/id");
            foreach (XmlNode idNode in idNodes)
            {
                int currentId;
                if (int.TryParse(idNode.InnerText, out currentId))
                {
                    if (currentId > maxId)
                    {
                        maxId = currentId;
                    }
                }
            }


            XmlNode PasswordList = dc.CreateElement("Passwords");
            XmlNode Website = dc.CreateElement("Website");
            Website.InnerText = "First";
            PasswordList.AppendChild(Website);

            XmlNode Username = dc.CreateElement("Username");
            Username.InnerText = "Time";
            PasswordList.AppendChild(Username);

            XmlNode Password = dc.CreateElement("Password");
            Password.InnerText = firstpass;
            PasswordList.AppendChild(Password);

            XmlNode User = dc.CreateElement("User");
            User.InnerText = Properties.Settings.Default.Account;
            PasswordList.AppendChild(User);

            XmlNode number = dc.CreateElement("id");
            number.InnerText = (maxId + 1).ToString();
            PasswordList.AppendChild(number);

            XmlNode Locator = dc.CreateElement("Location");
            Locator.InnerText = "Favourite";
            PasswordList.AppendChild(Locator);

            dc.DocumentElement.AppendChild(PasswordList);

            dc.Save(xmlFilePath);
        }
        public void Firstschool()
        {
            string firstpass = "";
            byte[] data = UTF8Encoding.UTF8.GetBytes("School");
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(crypt));
                using (TripleDESCryptoServiceProvider tripdes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripdes.CreateEncryptor();

                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    firstpass = Convert.ToBase64String(results, 0, results.Length);
                }
            }
            string xmlFilePath = @"Passwordlist.xml";
            XmlDocument dc = new XmlDocument();
            dc.Load(xmlFilePath);

            int maxId = 0;
            XmlNodeList idNodes = dc.SelectNodes("//Passwords/id");
            foreach (XmlNode idNode in idNodes)
            {
                int currentId;
                if (int.TryParse(idNode.InnerText, out currentId))
                {
                    if (currentId > maxId)
                    {
                        maxId = currentId;
                    }
                }
            }


            XmlNode PasswordList = dc.CreateElement("Passwords");
            XmlNode Website = dc.CreateElement("Website");
            Website.InnerText = "First";
            PasswordList.AppendChild(Website);

            XmlNode Username = dc.CreateElement("Username");
            Username.InnerText = "Time";
            PasswordList.AppendChild(Username);

            XmlNode Password = dc.CreateElement("Password");
            Password.InnerText = firstpass;
            PasswordList.AppendChild(Password);

            XmlNode User = dc.CreateElement("User");
            User.InnerText = Properties.Settings.Default.Account;
            PasswordList.AppendChild(User);

            XmlNode number = dc.CreateElement("id");
            number.InnerText = (maxId + 1).ToString();
            PasswordList.AppendChild(number);

            XmlNode Locator = dc.CreateElement("Location");
            Locator.InnerText = "School";
            PasswordList.AppendChild(Locator);

            dc.DocumentElement.AppendChild(PasswordList);

            dc.Save(xmlFilePath);
        }
        public void Firstwork()
        {
            string firstpass = "";
            byte[] data = UTF8Encoding.UTF8.GetBytes("Work");
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(crypt));
                using (TripleDESCryptoServiceProvider tripdes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripdes.CreateEncryptor();

                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    firstpass = Convert.ToBase64String(results, 0, results.Length);
                }
            }
            string xmlFilePath = @"Passwordlist.xml";
            XmlDocument dc = new XmlDocument();
            dc.Load(xmlFilePath);

            int maxId = 0;
            XmlNodeList idNodes = dc.SelectNodes("//Passwords/id");
            foreach (XmlNode idNode in idNodes)
            {
                int currentId;
                if (int.TryParse(idNode.InnerText, out currentId))
                {
                    if (currentId > maxId)
                    {
                        maxId = currentId;
                    }
                }
            }


            XmlNode PasswordList = dc.CreateElement("Passwords");
            XmlNode Website = dc.CreateElement("Website");
            Website.InnerText = "First";
            PasswordList.AppendChild(Website);

            XmlNode Username = dc.CreateElement("Username");
            Username.InnerText = "Time";
            PasswordList.AppendChild(Username);

            XmlNode Password = dc.CreateElement("Password");
            Password.InnerText = firstpass;
            PasswordList.AppendChild(Password);

            XmlNode User = dc.CreateElement("User");
            User.InnerText = Properties.Settings.Default.Account;
            PasswordList.AppendChild(User);

            XmlNode number = dc.CreateElement("id");
            number.InnerText = (maxId + 1).ToString();
            PasswordList.AppendChild(number);

            XmlNode Locator = dc.CreateElement("Location");
            Locator.InnerText = "Work";
            PasswordList.AppendChild(Locator);

            dc.DocumentElement.AppendChild(PasswordList);

            dc.Save(xmlFilePath);
        }
        static string DecryptBase64(string base64String)
        {
            
                byte[] data = Convert.FromBase64String(base64String);
                return System.Text.Encoding.UTF8.GetString(data);
            
        }
        static IEnumerable<XElement> GetRowsWithSpecificValue(XDocument doc, string targetValue)
        {
            return doc.Descendants("Passwords")
                      .Where(row => row.Elements("User").Any(column => column.Value == targetValue));
        }
        bool Firsttime(XDocument doc, string targetValue)
        {
            return doc.Descendants("Passwords")
                  .Any(row => row.Elements("User").Any(column => column.Value == targetValue));
        }

        public void Setting()
        {
            startup x = new startup();

            x.account1 = account1;
            x.Show();
            this.Close();
        }

        private void New_Click(object sender, EventArgs e)
        {
            string ac = Properties.Settings.Default.Account;
            Form2 f2 = new Form2();
            f2.current = Properties.Settings.Default.Account;
            f2.ShowDialog();
        }

        private void Edit_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string filePath = Passlist;

            string currentHash = GetXmlHash(filePath);

            if (!IsHashSame(currentHash, "previousHash.txt"))
            {
                Form1_Load(sender, e);
                File.WriteAllText("previousHash.txt", currentHash);
            }

        }
        static string GetXmlHash(string filePath)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    byte[] hashBytes = md5.ComputeHash(stream);
                    return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                }
            }
        }

        static bool IsHashSame(string currentHash, string previousHashFilePath)
        {
            if (File.Exists(previousHashFilePath))
            {
                string previousHash = File.ReadAllText(previousHashFilePath);
                return currentHash == previousHash;
            }

            return false;
        }
        private void Form1_DoubleClick(object sender, EventArgs e)
        {

        }

        public void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {



        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form3 open = new Form3();
            open.ShowDialog();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Settings_Click(object sender, EventArgs e)
        {
            startup x = new startup();
            x.account1 = account1;
            x.Show();
            this.Close();
        }


       

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 2 && !string.IsNullOrEmpty(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString()))
            {
                try
                {
                    string encryptedValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    string crypt = "f0xle@rn";
                    byte[] data = Convert.FromBase64String(encryptedValue);

                    using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                    {
                        byte[] keys = md5.ComputeHash(Encoding.UTF8.GetBytes(crypt));

                        using (TripleDESCryptoServiceProvider tripdes = new TripleDESCryptoServiceProvider()
                        {
                            Key = keys,
                            Mode = CipherMode.ECB,
                            Padding = PaddingMode.PKCS7
                        })
                        {
                            ICryptoTransform transform = tripdes.CreateDecryptor();

                            byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Encoding.UTF8.GetString(results);
                        }
                    }
                }
                catch (System.Exception ex)
                {
                   
                    Console.WriteLine("Error decrypting cell value: " + ex.Message);
                }
            }

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login x = new Login();
            x.Show();
            this.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 x = new Form2();
            x.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string web = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                web = "www." + web + ".com";


                System.Diagnostics.Process.Start(web);
            }
            if (e.ColumnIndex == 2)
            {
                string ID;

                EditDelete edit = new EditDelete();
                edit.cwebsite = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                edit.cusername = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                edit.cpassword = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                edit.id = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                edit.Editweb.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                edit.Edituser.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                edit.Editpass.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                ID = edit.id;
                edit.ShowDialog();

                if (edit.delete == false)
                {
                    var xdoc = XDocument.Load(Passlist);
                    var tgt = xdoc.Root.Descendants("Passwords").FirstOrDefault(x => x.Element("id").Value == ID);
                    var website = tgt.Descendants("Website").FirstOrDefault();
                    var username = tgt.Descendants("Username").FirstOrDefault();
                    var password = tgt.Descendants("Password").FirstOrDefault();
                    website.Value = edit.Editweb.Text;
                    username.Value = edit.Edituser.Text;
                    password.Value = edit.Editpass.Text;
                    xdoc.Save(Passlist);
                }


                if (edit.delete == true)
                {
                    var xdoc = XDocument.Load(Passlist);
                    var tgt = xdoc.Root.Descendants("Passwords").FirstOrDefault(x => x.Element("id").Value == ID);
                    tgt.Remove();


                    xdoc.Save(Passlist);
                }
            }
        }

        private void Tab_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string web = passall.CurrentRow.Cells[0].Value.ToString();
                web = "www." + web + ".com";


                System.Diagnostics.Process.Start(web);
            }
            if (e.ColumnIndex == 2)
            {
                string ID;

                EditDelete edit = new EditDelete();
                edit.cwebsite = passall.CurrentRow.Cells[0].Value.ToString();
                edit.cusername = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                edit.cpassword = passall.CurrentRow.Cells[2].Value.ToString();
                edit.id = passall.CurrentRow.Cells[4].Value.ToString();
                edit.Editweb.Text = passall.CurrentRow.Cells[0].Value.ToString();
                edit.Edituser.Text = passall.CurrentRow.Cells[1].Value.ToString();
                edit.Editpass.Text = passall.CurrentRow.Cells[2].Value.ToString();
                ID = edit.id;
                edit.ShowDialog();

                if (edit.delete == false)
                {
                    var xdoc = XDocument.Load(Passlist);
                    var tgt = xdoc.Root.Descendants("Passwords").FirstOrDefault(x => x.Element("id").Value == ID);
                    var website = tgt.Descendants("Website").FirstOrDefault();
                    var username = tgt.Descendants("Username").FirstOrDefault();
                    var password = tgt.Descendants("Password").FirstOrDefault();
                    website.Value = edit.Editweb.Text;
                    username.Value = edit.Edituser.Text;
                    password.Value = edit.Editpass.Text;
                    xdoc.Save(Passlist);
                }


                if (edit.delete == true)
                {
                    var xdoc = XDocument.Load(Passlist);
                    var tgt = xdoc.Root.Descendants("Passwords").FirstOrDefault(x => x.Element("id").Value == ID);
                    tgt.Remove();


                    xdoc.Save(Passlist);
                }
            }
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string web = passall.CurrentRow.Cells[0].Value.ToString();
                web = "www." + web + ".com";


                System.Diagnostics.Process.Start(web);
            }
            if (e.ColumnIndex == 2)
            {
                string ID;

                EditDelete edit = new EditDelete();
                edit.cwebsite = passall.CurrentRow.Cells[0].Value.ToString();
                edit.cusername = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                edit.cpassword = passall.CurrentRow.Cells[2].Value.ToString();
                edit.id = passall.CurrentRow.Cells[4].Value.ToString();
                edit.Editweb.Text = passall.CurrentRow.Cells[0].Value.ToString();
                edit.Edituser.Text = passall.CurrentRow.Cells[1].Value.ToString();
                edit.Editpass.Text = passall.CurrentRow.Cells[2].Value.ToString();
                ID = edit.id;
                edit.ShowDialog();

                if (edit.delete == false)
                {
                    var xdoc = XDocument.Load(Passlist);
                    var tgt = xdoc.Root.Descendants("Passwords").FirstOrDefault(x => x.Element("id").Value == ID);
                    var website = tgt.Descendants("Website").Single();
                    var username = tgt.Descendants("Username").Single();
                    var password = tgt.Descendants("Password").Single();
                    website.Value = edit.Editweb.Text;
                    username.Value = edit.Edituser.Text;
                    password.Value = edit.Editpass.Text;
                    xdoc.Save(Passlist);
                }


                if (edit.delete == true)
                {
                    var xdoc = XDocument.Load(Passlist);
                    var tgt = xdoc.Root.Descendants("Passwords").FirstOrDefault(x => x.Element("id").Value == ID);
                    tgt.Remove();


                    xdoc.Save(Passlist);
                }
            }
        }

        private void dataGridView2_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 2 && !string.IsNullOrEmpty(passall.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString()))
            {
                try
                {
                    string encryptedValue = passall.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    string crypt = "f0xle@rn";
                    byte[] data = Convert.FromBase64String(encryptedValue);

                    using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                    {
                        byte[] keys = md5.ComputeHash(Encoding.UTF8.GetBytes(crypt));

                        using (TripleDESCryptoServiceProvider tripdes = new TripleDESCryptoServiceProvider()
                        {
                            Key = keys,
                            Mode = CipherMode.ECB,
                            Padding = PaddingMode.PKCS7
                        })
                        {
                            ICryptoTransform transform = tripdes.CreateDecryptor();

                            byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                            passall.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Encoding.UTF8.GetString(results);
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    
                    Console.WriteLine("Error decrypting cell value: " + ex.Message);
                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void top()
        {
            List<string> websites = new List<string>();
            foreach (DataGridViewRow row in passall.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() != "")
                {
                    websites.Add(row.Cells[0].Value.ToString());
                }
            }

            // Count occurrences of each website
            Dictionary<string, int> websiteCounts = new Dictionary<string, int>();
            foreach (string website in websites)
            {
                if (websiteCounts.ContainsKey(website))
                {
                    websiteCounts[website]++;
                }
                else
                {
                    websiteCounts[website] = 1;
                }
            }

            // Display results in the output DataGridView
            Allweb.Rows.Clear();
            foreach (var kvp in websiteCounts)
            {
                Allweb.Rows.Add(kvp.Key, kvp.Value);
            }
            var sortedWebsiteCounts = websiteCounts.OrderByDescending(x => x.Value);

            // Display results in the output DataGridView
            Allweb.Rows.Clear();
            foreach (var kvp in sortedWebsiteCounts)
            {
                Allweb.Rows.Add(kvp.Key, kvp.Value);
            }
        }
        public void Work()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("User");
            Form form = new Form();
            DataGridView dataGridView1 = new DataGridView();
            dataGridView1.DataSource = dataTable;
            form.Controls.Add(dataGridView1);
            DataSet ds = new DataSet();
            ds.ReadXml(@"Passwordlist.xml");
            string coulmn = "User";
            var filteredrows = ds.Tables[0].AsEnumerable()
            .Where(row => row.Field<string>(coulmn) == account1)
            .Where(row => row.Field<string>("Location") == "Work")
            .CopyToDataTable();
            dataGridView3.DataSource = filteredrows;
            string hide = "User";
            if (dataGridView3.Columns.Contains(hide))
            {
                dataGridView3.Columns["Location"].Visible = false;
                dataGridView3.Columns[hide].Visible = false;
                dataGridView3.Columns["id"].Visible = false;
            }
            List<string> list = new List<string>();
            foreach (DataGridViewRow item in dataGridView3.Rows)
            {
                if (item.Cells.Count >= 2 && //atleast two columns
                    item.Cells[2].Value != null) //value is not null
                {
                    list.Add(item.Cells[2].Value.ToString());
                }
            }
            int score1 = 0;
            int count1 = dataGridView3.Rows.Count;
            foreach (var v in list)
            {

                string x = DecryptBase64(v.ToString());
                if (x.Length >= 8 && x.Length <= 11)
                {
                    score1 = score1 + 1;
                }
                if (x.Length >= 12 && x.Length <= 15)
                {
                    score1 = score1 + 2;
                }
                if (x.Length >= 16)
                {
                    score1 = score1 + 3;
                }
                if (Regex.IsMatch(x, @"[a-z]"))
                {
                    score1++;
                }
                if (Regex.IsMatch(x, @"[A-Z]"))
                {
                    score1++;
                }
                if (Regex.IsMatch(x, @"\d"))
                {
                    score1++;
                }
                if (Regex.IsMatch(x, @"[^\w]"))
                {
                    score1++;
                }
            }
            progressBar3.Value = score1 / count1;
        }
        public void School()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("User");
            Form form = new Form();
            DataGridView dataGridView1 = new DataGridView();
            dataGridView1.DataSource = dataTable;
            form.Controls.Add(dataGridView1);
            DataSet ds = new DataSet();
            ds.ReadXml(@"Passwordlist.xml");
            string coulmn = "User";
            var filteredrows = ds.Tables[0].AsEnumerable()
            .Where(row => row.Field<string>(coulmn) == account1)
            .Where(row => row.Field<string>("Location") == "School")
            .CopyToDataTable();
            dataGridView2.DataSource = filteredrows;
            string hide = "User";
            if (dataGridView2.Columns.Contains(hide))
            {
                dataGridView2.Columns["Location"].Visible = false;
                dataGridView2.Columns[hide].Visible = false;
                dataGridView2.Columns["id"].Visible = false;
            }
            List<string> list = new List<string>();
            foreach (DataGridViewRow item in dataGridView2.Rows)
            {
                if (item.Cells.Count >= 2 && //atleast two columns
                    item.Cells[2].Value != null) //value is not null
                {
                    list.Add(item.Cells[2].Value.ToString());
                }
            }
            int score1 = 0;
            int count1 = dataGridView2.Rows.Count;
            foreach (var v in list)
            {

                string x = DecryptBase64(v.ToString());
                if (x.Length >= 8 && x.Length <= 11)
                {
                    score1 = score1 + 1;
                }
                if (x.Length >= 12 && x.Length <= 15)
                {
                    score1 = score1 + 2;
                }
                if (x.Length >= 16)
                {
                    score1 = score1 + 3;
                }
                if (Regex.IsMatch(x, @"[a-z]"))
                {
                    score1++;
                }
                if (Regex.IsMatch(x, @"[A-Z]"))
                {
                    score1++;
                }
                if (Regex.IsMatch(x, @"\d"))
                {
                    score1++;
                }
                if (Regex.IsMatch(x, @"[^\w]"))
                {
                    score1++;
                }
            }
            progressBar2.Value = score1 / count1;
        }
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Find_Click(object sender, EventArgs e)
        {

            string filterweb = Search.Text;
            string filteruser = Suser.Text;
            if (filterweb != "")
            {
                XDocument doc = XDocument.Load(Passlist);
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("User");
                Form form = new Form();
                DataGridView dataGridView = new DataGridView();
                dataGridView.DataSource = dataTable;
                form.Controls.Add(dataGridView);
                var ch = GetRowsWithSpecificValue(doc, account1);
                DataSet ds = new DataSet();
                ds.ReadXml(Passlist);
                string coulmn = "User";
                var filteredrows = ds.Tables[0].AsEnumerable()
                    .Where(row => row.Field<string>(coulmn) == account1)
                    .Where(row => row.Field<string>("Website") == filterweb)
                    .CopyToDataTable();
                SearchWeb.DataSource = filteredrows;
                string hide = "User";
                if (SearchWeb.Columns.Contains(hide))
                {
                    SearchWeb.Columns[hide].Visible = false;
                    SearchWeb.Columns["id"].Visible = false;
                }
            }
            if (filterweb == "" && filteruser != "")

            {
                XDocument doc = XDocument.Load(Passlist);
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("User");
                Form form = new Form();
                DataGridView dataGridView = new DataGridView();
                dataGridView.DataSource = dataTable;
                form.Controls.Add(dataGridView);
                var ch = GetRowsWithSpecificValue(doc, account1);
                DataSet ds = new DataSet();
                ds.ReadXml(Passlist);
                string coulmn = "User";
                var filteredrows = ds.Tables[0].AsEnumerable()
                    .Where(row => row.Field<string>(coulmn) == account1)
                    .Where(row => row.Field<string>("Username") == filteruser)
                    .CopyToDataTable();
                SearchWeb.DataSource = filteredrows;
                string hide = "User";
                if (SearchWeb.Columns.Contains(hide))
                {
                    SearchWeb.Columns[hide].Visible = false;
                    SearchWeb.Columns["id"].Visible = false;
                }
            }


        }

        public void Allweb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string website = Allweb.CurrentRow.Cells[0].Value.ToString();
            Allwebsites x = new Allwebsites();
            x.certainwebsites = website;
            x.ShowDialog();
        }

        private void HomePage_Click(object sender, EventArgs e)
        {

        }

        private void SearchWeb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 2 && !string.IsNullOrEmpty(dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString()))
            {
                try
                {
                    string encryptedValue = dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    string crypt = "f0xle@rn";
                    byte[] data = Convert.FromBase64String(encryptedValue);

                    using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                    {
                        byte[] keys = md5.ComputeHash(Encoding.UTF8.GetBytes(crypt));

                        using (TripleDESCryptoServiceProvider tripdes = new TripleDESCryptoServiceProvider()
                        {
                            Key = keys,
                            Mode = CipherMode.ECB,
                            Padding = PaddingMode.PKCS7
                        })
                        {
                            ICryptoTransform transform = tripdes.CreateDecryptor();

                            byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                            dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Encoding.UTF8.GetString(results);
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    // Handle decryption errors appropriately (e.g., log, notify user, etc.)
                    Console.WriteLine("Error decrypting cell value: " + ex.Message);
                }
            }
        }

        private void dataGridView2_CellMouseEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 2 && !string.IsNullOrEmpty(dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString()))
            {
                try
                {
                    string encryptedValue = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    string crypt = "f0xle@rn";
                    byte[] data = Convert.FromBase64String(encryptedValue);

                    using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                    {
                        byte[] keys = md5.ComputeHash(Encoding.UTF8.GetBytes(crypt));

                        using (TripleDESCryptoServiceProvider tripdes = new TripleDESCryptoServiceProvider()
                        {
                            Key = keys,
                            Mode = CipherMode.ECB,
                            Padding = PaddingMode.PKCS7
                        })
                        {
                            ICryptoTransform transform = tripdes.CreateDecryptor();

                            byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                            dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Encoding.UTF8.GetString(results);
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    // Handle decryption errors appropriately (e.g., log, notify user, etc.)
                    Console.WriteLine("Error decrypting cell value: " + ex.Message);
                }
            }
        }

        


        public void weak()
        {
           

        }



        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}


