using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace NEA_Password_manager
{
    public partial class startup : MaterialForm
    {
        public startup()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

        }
        MaterialSkinManager ThemeManager = MaterialSkinManager.Instance;
       
        public bool AU { get; set; }
        private void startup_Load(object sender, EventArgs e)
        {

        }
        public string account1 { get; set; }
        public string colour;
        public void theme(object sender, EventArgs e)
        {

        }
        

        private void Save_Click(object sender, EventArgs e)
        {
            if (AU == true)
            {
                if (PASS.Text == "")
                {
                    MessageBox.Show("make a new password");
                }
                else
                {
                    Form1 x = new Form1();
                    this.Close();
                    x.log = true;
                    x.acc = account1;
                    x.Show();
                }
            }
            else
            {
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
                string crypt = "f0xle@rn";
                byte[] data = UTF8Encoding.UTF8.GetBytes(PASS.Text);
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(crypt));
                    using (TripleDESCryptoServiceProvider tripdes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                    {
                        ICryptoTransform transform = tripdes.CreateEncryptor();

                        byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                        PASS.Text = Convert.ToBase64String(results, 0, results.Length);
                    }
                }

                XmlNode PasswordList = dc.CreateElement("Passwords");
                XmlNode Website = dc.CreateElement("Website");
                Website.InnerText = WEB.Text;
                PasswordList.AppendChild(Website);

                XmlNode Username = dc.CreateElement("Username");
                Username.InnerText = USER.Text;
                PasswordList.AppendChild(Username);

                XmlNode Password = dc.CreateElement("Password");
                Password.InnerText = PASS.Text;
                PasswordList.AppendChild(Password);

                XmlNode User = dc.CreateElement("User");
                User.InnerText = account1;
                PasswordList.AppendChild(User);

                XmlNode number = dc.CreateElement("id");
                number.InnerText = (maxId + 1).ToString();
                PasswordList.AppendChild(number);

                dc.DocumentElement.AppendChild(PasswordList);

                dc.Save(xmlFilePath);
                set = true;
                Form1 x = new Form1();
                x.log = true;
                x.acc = account1;
                x.Show();
                this.Close();

            }
        }

        public void materialRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ThemeManager.ColorScheme = new ColorScheme(Primary.Blue700, Primary.Blue900, Primary.Blue500, Accent.Blue400, TextShade.WHITE);
            colour = "ThemeManager.ColorScheme = new ColorScheme(Primary.Blue700, Primary.Blue900, Primary.Blue500, Accent.Blue400, TextShade.WHITE);";
        }

        public void materialRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ThemeManager.ColorScheme = new ColorScheme(Primary.Green700, Primary.Green900, Primary.Green500, Accent.Green400, TextShade.WHITE);
            colour = "ThemeManager.ColorScheme = new ColorScheme(Primary.Green700, Primary.Green900, Primary.Green500, Accent.Green400, TextShade.WHITE);";
        }

        public void materialRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            ThemeManager.ColorScheme = new ColorScheme(Primary.Amber700, Primary.Amber900, Primary.Amber500, Accent.Amber400, TextShade.WHITE);
            colour = "ThemeManager.ColorScheme = new ColorScheme(Primary.Amber700, Primary.Amber900, Primary.Amber500, Accent.Amber400, TextShade.WHITE);";
        }
        public bool set = false;

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Home_Click(object sender, EventArgs e)
        {
            Form1 x = new Form1();
            x.acc = account1;
            this.Close();
            x.Reload(sender, e);
            x.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Authentification x = new Authentification();
            x.ShowDialog();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            string filePath = @"CustomFolder";
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(filePath);
            }
            catch (Exception)
            {
                // If the file doesn't exist, create a new XML document
                XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                xmlDoc.AppendChild(xmlDeclaration);

                XmlElement root = xmlDoc.CreateElement("CustomFolder");
                xmlDoc.AppendChild(root);
            }

            // Get the root element
            XmlElement rootElement = xmlDoc.DocumentElement;

            // Replace or add the "Email" and "2fa" values
            string email = Properties.Settings.Default.Account;
            string name = Foldername.Text;


            UpdateOrCreateValue(xmlDoc, rootElement, "Email", email);
            UpdateOrCreateValue(xmlDoc, rootElement, "Folder", name);
            // Save the changes
            xmlDoc.Save(filePath);
        }
        static void UpdateOrCreateValue(XmlDocument xmlDoc, XmlElement rootElement, string key, string value)
        {
            // Check if the key already exists
            XmlNode existingNode = rootElement.SelectSingleNode(key);
            if (existingNode != null)
            {
                // If the key exists, update the value
                existingNode.InnerText = value;
            }
            else
            {
                // If the key doesn't exist, create a new element and add it to the root
                XmlElement newElement = xmlDoc.CreateElement(key);
                newElement.InnerText = value;
                rootElement.AppendChild(newElement);
            }
        }
    }
}
