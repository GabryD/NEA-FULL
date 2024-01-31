using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace NEA_Password_manager
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        public string factor { get; set; }
        private void Enter_Click(object sender, EventArgs e)
        {

            if (FA.Text == factor)
            {
                Form1 x = new Form1();
                x.Show();
                this.Close();

            }
        }
    }
}
