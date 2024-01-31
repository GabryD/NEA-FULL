using System;
using System.Windows.Forms;
using System.Xml;


namespace NEA_Password_manager
{
    static class Program
    {

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
        const string passfile = @"Passwordfile.xml";

        public static string randomNumber { get; set; }

        static void XmlFile()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("PasswordsFile.xml");
            doc.AppendChild(root);
            doc.Save(passfile);

        }


    }
}
