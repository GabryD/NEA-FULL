using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace NEA_Password_manager
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        
        public void Save_Click(object sender, EventArgs e)
        {
            int id = 1;
            XmlDocument dc= new XmlDocument();
            dc.Load(@"G:\Gabry\a levels\computer science\NEA Password manager\NEA Password manager\bin\Debug\Passwordlist.xml");
            XmlNode PasswordList = dc.CreateElement("Passwords");
            XmlNode number = dc.CreateElement("id");
            number.InnerText = id.ToString();
            PasswordList.AppendChild(number);
            XmlNode Website = dc.CreateElement("Website");
            Website.InnerText = F2Website.Text;
            PasswordList.AppendChild(Website);
            XmlNode Username = dc.CreateElement("Username");
            Username.InnerText = F2Username.Text;
            PasswordList.AppendChild(Username);
            XmlNode Password = dc.CreateElement("Password");
            Password.InnerText = F2Password.Text;
            PasswordList.AppendChild(Password);
            dc.DocumentElement.AppendChild(PasswordList);
            dc.Save("G:\\Gabry\\a levels\\computer science\\NEA Password manager\\NEA Password manager\\bin\\Debug\\Passwordlist.xml");
            id++;
            Close();
           

        }
    }
}
