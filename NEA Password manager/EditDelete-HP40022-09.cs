using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Xml.XmlConfiguration;
using System.Xml;
using System.Xml.Linq;
using System.Security.Cryptography;
using Microsoft.Office.Interop.Outlook;

namespace NEA_Password_manager
{

    public partial class EditDelete : Form
    {
        const string passfile = @"\\TCHS-SVR-FILE1\UserData$\Students\2017\GDalCol\a level year 13\NEA\NEA Password manager\bin\Debug\Passwordlist.xml";
        public EditDelete()
        {
            InitializeComponent();
            
        }

        

        public string cwebsite { get; set; }
        public string cusername { get; set; }
        public string cpassword { get; set; }
        public string id { get; set; }
        public bool delete { get; set; }

        


        private void EditDelete_Load(object sender, EventArgs e)
        {

            string crypt = "f0xle@rn";
            byte[] data = Convert.FromBase64String(Editpass.Text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(crypt));
                using (TripleDESCryptoServiceProvider tripdes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripdes.CreateDecryptor();

                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    Editpass.Text = UTF8Encoding.UTF8.GetString(results);
                }
            }

        }

        public void Update_Click(object sender, EventArgs e)
        {
           string cw = cwebsite;
            string crypt = "f0xle@rn";
            string cu = Properties.Settings.Default.Account;
            byte[] data = UTF8Encoding.UTF8.GetBytes(Editpass.Text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(crypt));
                using (TripleDESCryptoServiceProvider tripdes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripdes.CreateEncryptor();

                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    Editpass.Text = Convert.ToBase64String(results, 0, results.Length);
                }
            }
            string cp = Editpass.Text;  
            delete = false;


            Close();
        }

        public void Delete_Click(object sender, EventArgs e)
        {
            
            delete = true;
            Close();
        }
    }
}
