using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA_Password_manager
{
    public partial class easter : Form
    {
        public easter()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 x = new Form1();
            x.Show();
            SoundPlayer simpleSound = new SoundPlayer(@"\\TCHS-SVR-FILE1\UserData$\Students\2017\GDalCol\a level year 13\NEA\NEA Password manager\v09044g40000ckujre7og65g086nettg.wav");
            simpleSound.Stop();
            this.Close();
        }

        public void easter_Load(object sender, EventArgs e)
        {
            
                SoundPlayer simpleSound = new SoundPlayer(@"\\TCHS-SVR-FILE1\UserData$\Students\2017\GDalCol\a level year 13\NEA\NEA Password manager\v09044g40000ckujre7og65g086nettg.wav");
                simpleSound.Play();
            
        }
    }
}
