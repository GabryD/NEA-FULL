using MaterialSkin;
using MaterialSkin.Controls;
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
    public partial class TemporaryLogin : MaterialForm
    {
        public TemporaryLogin()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            TIMER.Interval = 60000; // 1min
            TIMER.Tick += TIMER_Tick;
            TIMER.Start();
        }
        public string Temp { get; set; }
        private void TemporaryLogin_Load(object sender, EventArgs e)
        {
            Login x = new Login();
            x.Show();
            this.Close();
        }

        private void TLOG_Click(object sender, EventArgs e)
        {
            if (Temporary.Text == Temp)
            {
                Form1 x = new Form1();
                x.Show();
                this.Close();
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Login x = new Login();
            x.Show();
            this.Close();
        }

        private void TIMER_Tick(object sender, EventArgs e)
        {
            Login x = new Login();
            x.Show();
            this.Close();
        }
    }
}
