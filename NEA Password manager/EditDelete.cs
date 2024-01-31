using System;
using System.Text;
using System.Security.Cryptography;
using MaterialSkin;
using MaterialSkin.Controls;

namespace NEA_Password_manager
{

    public partial class EditDelete : MaterialForm
    {
        const string passfile = @"G:\Gabry\a levels\computer science\NEA\NEA Password manager\bin\Debug\Passwordlist.xml";
        public EditDelete()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            InitializeComponent();
            Form1Instance = new Form1();
        }
        public Form1 Form1Instance;


        public string cwebsite { get; set; }
        public string cusername { get; set; }
        public string cpassword { get; set; }
        public string id { get; set; }
        public bool delete { get; set; }



        
        private void EditDelete_Load(object sender, EventArgs e)
        {



        }

        public void Update_Click(object sender, EventArgs e)
        {
            string cw = cwebsite;
            string crypt = "f0xle@rn";
            string cu = cusername;
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

            Form1Instance.Reload(sender, e);
            Close();
        }

        public void Delete_Click(object sender, EventArgs e)
        {
            Form1Instance.Reload(sender, e);
            delete = true;
            Close();
        }
    }
}
