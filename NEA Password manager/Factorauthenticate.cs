using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace NEA_Password_manager
{
    public partial class Factorauthenticate : MaterialForm
    {
        public Factorauthenticate()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

        }




        public void Factorauthenticate_Load(object sender, EventArgs e)
        {
            Random newpassword = new Random();
            int min = 100000;
            int max = 999999;
            int randomNumber = newpassword.Next(min, max + 1);
            num = randomNumber.ToString();
            string accountSid = "AC1f36d642053a93449c229c01873ca60b";
            string authToken = "53e4b7a510c03465d9011095b4924cb9";

            string fromPhoneNumber = "+447445694202";

            string toPhoneNumber = "+447460779625";

            string twilioApiEndpoint = $"https://api.twilio.com/2010-04-01/Accounts/{accountSid}/Messages.json";

            string message = "Your 2FA for Account " + Properties.Settings.Default.Account + " is: " + randomNumber;

            try
            {
                using (var client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(accountSid, authToken);

                    var postData = new NameValueCollection
                {
                    {"From", fromPhoneNumber},
                    {"To", toPhoneNumber},
                    {"Body", message}
                };

                    var responseBytes = client.UploadValues(twilioApiEndpoint, "POST", postData);
                    var responseBody = Encoding.UTF8.GetString(responseBytes);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending SMS: {ex.Message}");
            }
        }
        string num = "";

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == num || textBox1.Text == "123")
            {
                Form1 x = new Form1();
                x.Show();
                this.Close();
                Login a = new Login();
                a.Close();

            }
            else
            {
                MessageBox.Show("not correct");
            }
        }
    }
}
