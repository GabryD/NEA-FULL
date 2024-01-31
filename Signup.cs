using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace NEA_Password_manager
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
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

            XmlSerializer xs = new XmlSerializer(typeof(User));
            using (FileStream fs = new FileStream("Data.xml", FileMode.Create))
            {
                xs.Serialize(fs, users);
            }
           // dc.Load(@"G:\Gabry\a levels\computer science\NEA Password manager\NEA Password manager\bin\Debug\Login.xml");
            Login x = new Login();
            x.Show();
            this.Close();
        }
    }
}
