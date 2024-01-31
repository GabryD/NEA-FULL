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

namespace NEA_Password_manager
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        
        public string FromXML_pwd = "";
        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void Log_Click(object sender, EventArgs e)
        {
            
            string pwd = Pin.Text;
            XDocument doc = XDocument.Load(Application.StartupPath.ToString() + @"\Data.xml");
            var selected_user = from x in doc.Descendants("User").Where
                (x => (string)x.Element("password") == Pin.Text)
                select new
                {
                    
                    XMLpwd = x.Element("password").Value
                };
            foreach (var x in selected_user)
            {
                
                FromXML_pwd= x.XMLpwd;
            }

            bool b = false;
            if (Pin.Text == "")
            {
                MessageBox.Show("please enter password");
            }
            else if (Pin.Text == FromXML_pwd)
            {
                Form1 x = new Form1();
                x.Show();
                b = true;
            }
            else
            {
                MessageBox.Show("wrong password","error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                
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
    }
}
