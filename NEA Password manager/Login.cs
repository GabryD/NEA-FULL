using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using MaterialSkin;
using MaterialSkin.Controls;


namespace NEA_Password_manager
{
    public partial class Login : MaterialForm
    {
        public Login()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);


        }

        public string FromXML_pwd = "";
        public string FromXML_Email = "";




        public string Temp { get; set; }

        private void Login_Load(object sender, EventArgs e)
        {
            string spas = @"closed.PNG";
            Bitmap closed = new Bitmap(spas);
            Show.Image = closed;
        }

        private void Log_Click(object sender, EventArgs e)
        {

            string pwd = Pin.Text;
            string username = Emailbox.Text;
            XDocument doc = XDocument.Load(Application.StartupPath.ToString() + @"\Login.xml");
            var selected_user = from d in doc.Descendants("Logins").Where
                                (x => (string)x.Element("Pin") == Pin.Text)

                                select new
                                {
                                    FromXML_Email = d.Element("Emails").Value,
                                    XMLpwd = d.Element("Pin").Value
                                };

            string FromXML_pwd = null;
            string FromXML_Email = null;
            foreach (var x in selected_user)
            {
                FromXML_Email = x.FromXML_Email;
                FromXML_pwd = x.XMLpwd;
            }
            string Phone = "";
            bool b = false;
            if (Pin.Text == "")
            {
                MessageBox.Show("Please Enter Password");
            }
            if (Emailbox.Text == FromXML_Email)
            {
                if (Pin.Text == FromXML_pwd)
                {
                    string usernameid = FromXML_Email;
                    Properties.Settings.Default.Account = usernameid;
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(@"2FA");
                    XmlNode phoneNode = xmlDoc.SelectSingleNode($"Root/Email[text()='{Emailbox.Text}']/following-sibling::TwoFactorAuth");
                    Phone = phoneNode != null ? phoneNode.InnerText : string.Empty;
                    Properties.Settings.Default.PhoneNum = Phone;
                    XmlNode onNode = xmlDoc.SelectSingleNode($"Root/Email[text()='{Emailbox.Text}']/following-sibling::On");
                    bool isOn = false;
                    if (onNode != null && onNode.InnerText == "y")
                    {
                        isOn = true;
                    }
                    else
                    {
                        isOn = false;

                    }
                    if (isOn == true)
                    {
                        Factorauthenticate a = new Factorauthenticate();
                        a.Show();
                        this.Close();
                    }
                    else
                    {
                        Form1 x = new Form1();
                        x.account1 = Emailbox.Text;
                        Properties.Settings.Default.Account = usernameid;
                        this.Close();
                        x.ShowDialog();
                        x.Reload(sender, e);
                        x.log = false;
                        b = true;
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Email Address or Password");
                    ClearBoxes();
                }
            }
            else
            {
                MessageBox.Show("Wrong Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearBoxes();

            }

            if (b == true)
            {
                this.Close();
            }
        }

        private void Signup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signup s = new Signup();
            s.Show();
            this.Close();
        }
        private void ClearBoxes()
        {
            Pin.Clear();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forgottenpassword x = new Forgottenpassword();
            x.Show();
            this.Close();
        }
        int showpassword = 1;
        private void Show_Click(object sender, EventArgs e)
        {
            string Cpas = @"\closed.PNG";
            string CPas = @"\open.PNG";
            showpassword *= -1;
            if (showpassword == -1)
            {
                Bitmap closed = new Bitmap(Cpas);
                Show.Image = closed;
                Pin.UseSystemPasswordChar = false;
            }
            else
            {
                Bitmap open = new Bitmap(CPas);
                Show.Image = open;
                Pin.UseSystemPasswordChar = true;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
