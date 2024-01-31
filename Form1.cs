using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Timers;

namespace NEA_Password_manager
{
    public partial class Form1 : Form
    {
        DataTable Passwords = new DataTable();
        
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 5000; // 5 seconds
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }
        
        
        private void Form1_Load(object sender, EventArgs e)
        {

            DataSet ds = new DataSet();
            ds.ReadXml(@"G:\\Gabry\\a levels\\computer science\\NEA Password manager\\NEA Password manager\\bin\\Debug\\Passwordlist.xml");
            dataGridView1.DataSource = ds.Tables[0];
              

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
            DataSet ds = new DataSet();
            ds.ReadXml(@"G:\\Gabry\\a levels\\computer science\\NEA Password manager\\NEA Password manager\\bin\\Debug\\Passwordlist.xml");
            dataGridView1.DataSource = ds.Tables[0];
        }
    }

}
