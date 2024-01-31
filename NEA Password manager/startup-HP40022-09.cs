using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

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
        private void themetoggle_CheckedChanged(object sender, EventArgs e)
        {
            if (themetoggle.Checked)
            {
                ThemeManager.Theme = MaterialSkinManager.Themes.DARK;
            }
            else
            {
                ThemeManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
        }
        public bool AU { get; set; }
        private void startup_Load(object sender, EventArgs e)
        {
            //if (AU == false)
            //{
            //    PASS.Enabled = false;
            //    WEB.Enabled = false;
            //    USER.Enabled = false;
            //    PASS.Visible = false;
            //    WEB.Visible = false;
            //    USER.Visible = false;
            //}
            //else
            //{
            //    PASS.Enabled = true;
            //    WEB.Enabled = true;
            //    USER.Enabled = true;
            //    PASS.Visible = true;
            //    WEB.Visible= true;
            //    USER.Visible = true;
            //}
        }
        public string account1 { get; set; }
        public string theme;
        public string colour;
        public void themetoggle_CheckedChanged_1(object sender, EventArgs e)
        {
            
            if (themetoggle.Checked)
            {
                ThemeManager.Theme = MaterialSkinManager.Themes.DARK;
                theme = "dark";
            }
            else
            {
                ThemeManager.Theme = MaterialSkinManager.Themes.LIGHT;
                theme = "light";
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (AU == true)
            {
                if (set == false)
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
                
                    Form1 x = new Form1();
                    this.Close();
                    x.log = true;
                    x.acc = account1;
                    x.Show();
                
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
            if (set == false)
            {


                string xmlFilePath = @"\\TCHS-SVR-FILE1\UserData$\Students\2017\GDalCol\a level year 13\NEA\NEA Password manager\bin\Debug\Passwordlist.xml";
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
                User.InnerText = Properties.Settings.Default.Account;
                PasswordList.AppendChild(User);

                XmlNode number = dc.CreateElement("id");
                number.InnerText = (maxId + 1).ToString();
                PasswordList.AppendChild(number);

                dc.DocumentElement.AppendChild(PasswordList);

                dc.Save(xmlFilePath);
                set = true;
            }
        }

        private void Home_Click(object sender, EventArgs e)
        {
            Form1 x = new Form1();
            this.Close();
            x.Show();
        }
    }
}
