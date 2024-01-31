using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;


namespace NEA_Password_manager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //XmlFile();
            Console.ReadLine();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Login x = new Login();
            x.Show();
            Application.Run();
               
            
        }

       
        static void XmlFile()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("PasswordsFile.xml");
            doc.AppendChild(root);
            doc.Save(@"G:\Gabry\a levels\computer science\NEA Password manager\NEA Password manager\PasswordsFile.xml");
            
        }

        
    }
}
