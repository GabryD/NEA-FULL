using System;
using System.Text;
using System.Xml;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Security.Cryptography;
using System.ComponentModel.Design.Serialization;
using Microsoft.Office.Interop.Outlook;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NEA_Password_manager
{
    public partial class Form2 : MaterialForm
    {
        
        public Form2()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }
        
        public string current { get; set; }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        string crypt = "f0xle@rn";
        public void Save_Click(object sender, EventArgs e)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(F2Password.Text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(crypt));
                using (TripleDESCryptoServiceProvider tripdes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripdes.CreateEncryptor();

                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    F2Password.Text = Convert.ToBase64String(results, 0, results.Length);
                }
            }
            string xmlFilePath = @"Passwordlist.xml";
            XmlDocument dc = new XmlDocument();
            dc.Load(xmlFilePath);
            string ac = current;

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
            string custom = "";
            string name = "";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"CustomFolder");
            XmlNode phoneNode = xmlDoc.SelectSingleNode($"CustomFolder/Email[text()='{Properties.Settings.Default.Account}']/following-sibling::Folder");
            name = phoneNode != null ? phoneNode.InnerText : string.Empty;
            if (Location.Text == name)
            {
                custom = "Custom";
            }

            XmlNode PasswordList = dc.CreateElement("Passwords");
            XmlNode Website = dc.CreateElement("Website");
            Website.InnerText = F2Website.Text;
            PasswordList.AppendChild(Website);

            XmlNode Username = dc.CreateElement("Username");
            Username.InnerText = F2Username.Text;
            PasswordList.AppendChild(Username);

            XmlNode Password = dc.CreateElement("Password");
            Password.InnerText = F2Password.Text;
            PasswordList.AppendChild(Password);

            XmlNode User = dc.CreateElement("User");
            User.InnerText = ac;
            PasswordList.AppendChild(User);

            XmlNode number = dc.CreateElement("id");
            number.InnerText = (maxId + 1).ToString();
            PasswordList.AppendChild(number);

            XmlNode Locator = dc.CreateElement("Location");
            Locator.InnerText = custom;
            PasswordList.AppendChild(Locator);

            dc.DocumentElement.AppendChild(PasswordList);

            dc.Save(xmlFilePath);
            Close();


        }



        public void Form2_Load(object sender, EventArgs e)
        {
            string name = "";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"CustomFolder");
            XmlNode phoneNode = xmlDoc.SelectSingleNode($"CustomFolder/Email[text()='{Properties.Settings.Default.Account}']/following-sibling::Folder");
            name = phoneNode != null ? phoneNode.InnerText : string.Empty;
            Location.Items.Add(name);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
