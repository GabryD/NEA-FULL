using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace NEA_Password_manager
{
    public partial class Signup : MaterialForm
    {
        public Signup()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void Email_TextChanged(object sender, EventArgs e)
        {

        }

        private void Pinword_TextChanged(object sender, EventArgs e)
        {

        }
        public class User
        {

            public string email;
            public string password;




            public string Email
            {
                get { return email; }
                set { email = value; }
            }

            public string Password
            {
                get { return password; }
                set { password = value; }
            }

            public User() { }

            public User(string Email, string password)
            {

                this.email = Email;
                this.password = password;
            }

        }
        private void sup_Click(object sender, EventArgs e)
        {
            User users = new User();
            users.email = Email.Text;
            users.password = Pinword.Text;
            bool safe = false;
            bool validemail = false;
            string check = users.password;

            if (safe == false)
            {
                bool special = false;
                bool l = false;
                if (check.Any(ch => !char.IsLetterOrDigit(ch)))
                {
                    special = true;
                }
                int length = check.Length - 1;
                if (length >= 7)
                {
                    l = true;
                }
                if (special == true)
                {
                    if (l == true)
                    {
                        safe = true;
                    }
                    else if (l == false)
                    {
                        MessageBox.Show("Password isnt 8 long");
                    }
                }
                else if (special == false)
                {
                    if (l == false)
                    {
                        MessageBox.Show("Password must be 8 characters long and cotain 1 special character");
                    }
                    MessageBox.Show("Password doesnt contain at least 1 special character");
                }
            }
           if (IsValidEmail(Email.Text))
            if (safe == true)
            {
                
                string xmlFilePath = @"\\TCHS-SVR-FILE1\UserData$\Students\2017\GDalCol\a level year 13\NEA\NEA Password manager\bin\Debug\Login.xml";
                XmlDocument dc = new XmlDocument();
                dc.Load(xmlFilePath);
                XmlNode LoginID = dc.CreateElement("Logins");

                XmlNode email = dc.CreateElement("Emails");
                email.InnerText = Email.Text;
                LoginID.AppendChild(email);

                XmlNode Pin = dc.CreateElement("Pin");
                Pin.InnerText = Pinword.Text;
                LoginID.AppendChild(Pin);

                dc.DocumentElement.AppendChild(LoginID);
                dc.Save(xmlFilePath);

                Login x = new Login();
                x.Show();
                this.Close();
            }
        }
        static bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            
            Regex regex = new Regex(pattern);
            
            return regex.IsMatch(email);
        }
        private void Signup_Load(object sender, EventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {
            Login x = new Login();
            x.Show();
            this.Close();
        }
        static string GeneratePassword(int length, int numDigits, int numSpecialChars)
        {
            string lowercaseChars = "abcdefghijklmnopqrstuvwxyz";
            string uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string digitChars = "0123456789";
            string specialChars = "!@#$%^&*()-_+=<>?";

            StringBuilder password = new StringBuilder();

            Random random = new Random();

   
            password.Append(digitChars[random.Next(digitChars.Length)]);


            password.Append(specialChars[random.Next(specialChars.Length)]);

            for (int i = 2; i < length; i++)
            {
                int category = random.Next(3);
                switch (category)
                {
                    case 0:
                        password.Append(lowercaseChars[random.Next(lowercaseChars.Length)]);
                        break;
                    case 1:
                        password.Append(uppercaseChars[random.Next(uppercaseChars.Length)]);
                        break;
                    case 2:
                        password.Append(specialChars[random.Next(specialChars.Length)]);
                        break;
                }
            }

            char[] passwordArray = password.ToString().ToCharArray();
            for (int i = 0; i < passwordArray.Length; i++)
            {
                int j = random.Next(i, passwordArray.Length);
                char temp = passwordArray[i];
                passwordArray[i] = passwordArray[j];
                passwordArray[j] = temp;
            }

            return new string(passwordArray);
        }

        private void Generate_Click(object sender, EventArgs e)
        {
            string Genpass = GeneratePassword(8, 1, 1);
            Pinword.Text = Genpass;
        }
    }

}
