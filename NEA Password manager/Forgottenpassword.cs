using System;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace NEA_Password_manager
{
    public partial class Forgottenpassword : Form
    {
        public Forgottenpassword()
        {
            InitializeComponent();
        }

        private void Forgottenpassword_Load(object sender, EventArgs e)
        {

        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void Send_Click(object sender, EventArgs e)
        {

            Random newpassword = new Random();
            int min = 100000;
            int max = 999999;
            int randomNumber = newpassword.Next(min, max + 1);
            string x = textBox1.Text;

            Outlook.Application outlookApp = new Outlook.Application();

            Outlook.MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);

            mailItem.Subject = "Temporany Pin";
            mailItem.Body = "Your temporany pin is: " + randomNumber.ToString() + ". You have one minute before it expires.";
            mailItem.To = x;
            mailItem.Send();

            System.Runtime.InteropServices.Marshal.ReleaseComObject(mailItem);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(outlookApp);
            Forgottenpassword close = new Forgottenpassword();

            TemporaryLogin temperary = new TemporaryLogin();
            temperary.ShowDialog();
            temperary.Temp = randomNumber.ToString();
            this.Close();

        }
    }
}
