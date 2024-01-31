using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Timers;
using System.Threading;
using System.Security.Cryptography;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Net;
using System.Net.Mail;

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

            Bitmap closed = new Bitmap(@"\\TCHS-SVR-FILE1\UserData$\Students\2017\GDalCol\a level year 13\NEA\NEA Password manager\open.PNG");
            //BackColor = Properties.Settings.Default.formcolour;
            Show.Image = closed;
        }

        public void Log_Click(object sender, EventArgs e)
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

            bool b = false;
            if (Pin.Text == "")
            {
                MessageBox.Show("Please Enter Password");
            }
            if (Emailbox.Text == FromXML_Email)
            {
                if (Pin.Text == FromXML_pwd)
                {
                    //string usernameid = FromXML_Email;
                    
                    
                    
                    //Properties.Settings.Default.Account = usernameid;
                    //Properties.Settings.Default.Save();
                    //Random newpassword = new Random();
                    //int min = 100000;
                    //int max = 999999;
                    //int randomNumber = newpassword.Next(min, max + 1);
                    //string fa = randomNumber.ToString();
                    //MailAddress to = new MailAddress(Properties.Settings.Default.Account);
                    //MailAddress from = new MailAddress(Properties.Settings.Default.Account);

                    //MailMessage email = new MailMessage(from, to);
                    //email.Subject = "2FA";
                    //email.Body = "Hello here is your 2fa password: " + fa;

                    //SmtpClient smtp = new SmtpClient();
                    //smtp.Host = "smtp-mail.outlook.com";
                    //smtp.Port = 25;
                    //smtp.Credentials = new NetworkCredential("Gdalcol@tchs.uk.net", "05Zorh");
                    //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //smtp.EnableSsl = true;

                    //try
                    //{
                    //    smtp.Send(email);
                    //}
                    //catch (SmtpException ex)
                    //{
                    //    Console.WriteLine(ex.ToString());
                    //}
                    Form1 x = new Form1();
                    //x.factor = randomNumber.ToString();
                    this.Close();
                    x.ShowDialog();
                    b = true;

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
            showpassword *= -1;
            if (showpassword == -1)
            {
                Bitmap closed = new Bitmap(@"\\TCHS-SVR-FILE1\UserData$\Students\2017\GDalCol\a level year 13\NEA\NEA Password manager\closed.PNG");
                Show.Image = closed;
                Pin.UseSystemPasswordChar = false;
            }
            else
            {
                Bitmap open = new Bitmap(@"\\TCHS-SVR-FILE1\UserData$\Students\2017\GDalCol\a level year 13\NEA\NEA Password manager\open.PNG");
                Show.Image = open;
                Pin.UseSystemPasswordChar = true;
            }

        }
    }
}
