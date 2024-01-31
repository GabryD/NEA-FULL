using MaterialSkin;
using MaterialSkin.Controls;
using RestSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace NEA_Password_manager
{
    public partial class Form1 : MaterialForm
    {
        DataTable Passwords = new DataTable();

        public Form1()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }
        public string filename = @"Passwordlist.xml";
        public string account1 { get; set; }
        public string acc { get; set; }
        public bool log { get; set; }
        
        public void Form1_Load(object sender, EventArgs e)
        {
            //@"\\TCHS-SVR-FILE1\UserData$\Students\2017\GDalCol\a level year 13\NEA\NEA Password manager\bin\Debug\Passwordlist.xml"
            XDocument doc = XDocument.Load(filename);
            string targetValue;
            if (account1 == null)
            {
                account1 = Properties.Settings.Default.Account;
               targetValue = Properties.Settings.Default.Account;
            }
            else
            {
                targetValue = Properties.Settings.Default.Account;
            }
            var filteredRows = GetRowsWithSpecificValue(doc, targetValue);
            bool hasdata = Firsttime(doc, targetValue);
            startup already = new startup();
            already.AU = hasdata;

            if (hasdata != true)
            {
                Setting();
            }
            else
            {


                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("User");
                foreach (var row in filteredRows)
                {
                    
                    
                }
                Form form = new Form();
                DataGridView dataGridView = new DataGridView();
                dataGridView.DataSource = dataTable;
                form.Controls.Add(dataGridView);
                var ch = GetRowsWithSpecificValue(doc, Properties.Settings.Default.Account);
                DataSet ds = new DataSet();
                ds.ReadXml(filename);
                string coulmn = "User";
                foreach (var row in filteredRows)
                {
                    
                }
                var filteredrows = ds.Tables[0].AsEnumerable()
                    .Where(row => row.Field<string>(coulmn) == account1)
                    .CopyToDataTable();
                dataGridView1.DataSource = filteredrows;
                string hide = "User";
                if (dataGridView1.Columns.Contains(hide))
                {
                    dataGridView1.Columns[hide].Visible = false;
                    dataGridView1.Columns["id"].Visible = false;
                }

            }
            
        }

        static IEnumerable<XElement> GetRowsWithSpecificValue(XDocument doc, string targetValue)
        {
            return doc.Descendants("Passwords")
                      .Where(row => row.Elements("User").Any(column => column.Value == targetValue));
        }
        bool Firsttime(XDocument doc, string targetValue)
        {
            return doc.Descendants("Passwords")
                  .Any(row => row.Elements("User").Any(column => column.Value == targetValue));
        }

        public void Setting()
        {
            startup x = new startup();
            x.Show();
            this.Close();
        }

        private void New_Click(object sender, EventArgs e)
        {
           
            Form2 f2 = new Form2();
       
            f2.ShowDialog();
        }

        private void Edit_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Form1_Load(sender, e);


        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {

        }

        public void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {



            string ID;

            EditDelete edit = new EditDelete();
            edit.cwebsite = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            edit.cusername = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            edit.cpassword = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            edit.id = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            edit.Editweb.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            edit.Edituser.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            edit.Editpass.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            ID = edit.id;
            edit.ShowDialog();

            if (edit.delete == false)
            {
                var xdoc = XDocument.Load(filename);
                var tgt = xdoc.Root.Descendants("Passwords").FirstOrDefault(x => x.Element("id").Value == ID);
                var website = tgt.Descendants("Website").FirstOrDefault();
                var username = tgt.Descendants("Username").FirstOrDefault();
                var password = tgt.Descendants("Password").FirstOrDefault();
                website.Value = edit.Editweb.Text;
                username.Value = edit.Edituser.Text;
                password.Value = edit.Editpass.Text;
                xdoc.Save(filename);
            }


            if (edit.delete == true)
            {
                var xdoc = XDocument.Load(filename);
                var tgt = xdoc.Root.Descendants("Passwords").FirstOrDefault(x => x.Element("id").Value == ID);
                tgt.Remove();


                xdoc.Save(filename);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form3 open = new Form3();
            open.ShowDialog();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Settings_Click(object sender, EventArgs e)
        {
            startup x = new startup();
            x.account1 = account1;
            x.Show();
            this.Close();
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 2 && !string.IsNullOrEmpty(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString()))
            {
                try
                {
                    string encryptedValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
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
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Encoding.UTF8.GetString(results);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle decryption errors appropriately (e.g., log, notify user, etc.)
                    Console.WriteLine("Error decrypting cell value: " + ex.Message);
                }
            }
        }

        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {
            
        }
        public bool east = false;
        public void panelLogo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            east = false;
            p2.Visible = true;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            tp.Visible = true;
            east = true;
        }

        private void tp_ValueChanged(object sender, EventArgs e)
        {
            bte.Visible = true;
        }

        private void bte_CheckedChanged(object sender, EventArgs e)
        {
            if (tp.Value == 10)
            {
                easter w = new easter();
                w.Show();
                this.Close();
            }
        }
    }
    
}
