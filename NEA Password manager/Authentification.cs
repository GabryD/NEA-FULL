using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Xml;

namespace NEA_Password_manager
{
    public partial class Authentification : MaterialForm
    {
        public Authentification()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void Authentification_Load(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {
            string filePath = @"2FA";
            string on = "";
            if (Enabled == true)
            {
                on = "y";
            }
            else
            {
                on = "n";
            }
            // Create or load the XML document
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(filePath);
            }
            catch (Exception)
            {
                // If the file doesn't exist, create a new XML document
                XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                xmlDoc.AppendChild(xmlDeclaration);

                XmlElement root = xmlDoc.CreateElement("Root");
                xmlDoc.AppendChild(root);
            }

            // Get the root element
            XmlElement rootElement = xmlDoc.DocumentElement;

            // Replace or add the "Email" and "2fa" values
            string email = Properties.Settings.Default.Account;
            string twoFactorAuth = Phone.Text;


            UpdateOrCreateValue(xmlDoc, rootElement, "Email", email);
            UpdateOrCreateValue(xmlDoc, rootElement, "TwoFactor", twoFactorAuth);
            UpdateOrCreateValue(xmlDoc, rootElement, "On", on);
            // Save the changes
            xmlDoc.Save(filePath);


            this.Close();
        }
        static void UpdateOrCreateValue(XmlDocument xmlDoc, XmlElement rootElement, string key, string value)
        {
            // Check if the key already exists
            XmlNode existingNode = rootElement.SelectSingleNode(key);
            if (existingNode != null)
            {
                // If the key exists, update the value
                existingNode.InnerText = value;
            }
            else
            {
                // If the key doesn't exist, create a new element and add it to the root
                XmlElement newElement = xmlDoc.CreateElement(key);
                newElement.InnerText = value;
                rootElement.AppendChild(newElement);
            }
        }
    }
}
