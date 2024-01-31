using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace NEA_Password_manager
{
    public partial class Allwebsites : MaterialForm
    {
        public Allwebsites()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }
        public string certainwebsites { get; set; }
        private void Allwebsites_Load(object sender, EventArgs e)
        {
            string web = certainwebsites;
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("User");
            Form form = new Form();
            DataGridView dataGridView1 = new DataGridView();
            dataGridView1.DataSource = dataTable;
            form.Controls.Add(dataGridView1);
            DataSet ds = new DataSet();
            ds.ReadXml(@"Passwordlist.xml");
            string coulmn = "User";
            var filteredrows = ds.Tables[0].AsEnumerable()
            .Where(row => row.Field<string>(coulmn) == Properties.Settings.Default.Account)
            .Where(row => row.Field<string>("Website") == web)
            .CopyToDataTable();
            cerweb.DataSource = filteredrows;
            string hide = "User";
            if (cerweb.Columns.Contains(hide))
            {
                cerweb.Columns["Location"].Visible = false;
                cerweb.Columns[hide].Visible = false;
                cerweb.Columns["id"].Visible = false;
            }


        }

        private void cerweb_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 2 && !string.IsNullOrEmpty(cerweb.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString()))
            {
                try
                {
                    string encryptedValue = cerweb.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    string crypt = "f0xle@rn";
                    byte[] data = Convert.FromBase64String(encryptedValue);

                    using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                    {
                        byte[] keys = md5.ComputeHash(Encoding.UTF8.GetBytes(crypt));

                        using (TripleDESCryptoServiceProvider tripdes = new TripleDESCryptoServiceProvider()
                        {
                            Key = keys,
                            Mode = CipherMode.ECB,
                            Padding = PaddingMode.PKCS7
                        })
                        {
                            ICryptoTransform transform = tripdes.CreateDecryptor();

                            byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                            cerweb.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Encoding.UTF8.GetString(results);
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    // Handle decryption errors appropriately (e.g., log, notify user, etc.)
                    Console.WriteLine("Error decrypting cell value: " + ex.Message);
                }
            }
        }
    }
}
