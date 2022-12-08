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

namespace JSGuru
{
    public partial class Main : Form
    {
        private SoundPlayer soundPlayer;
        private Random rnd;
        public Main()
        {
            InitializeComponent();
            soundPlayer = new SoundPlayer();
            rnd = new Random();
            soundPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "robot-6282.wav";
            soundPlayer.Play();
            this.timer.Start();
            if (Environment.OSVersion.Version.Major >= 6) SetProcessDPIAware();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            PanelMessage.row = 0;
            this.Hide();
            this.soundPlayer.Stop();
            form.ShowDialog();
            this.Show();
            this.soundPlayer.Play();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.pictureBox.Top = rnd.Next(600);
            this.pictureBox.Left = rnd.Next(950);
            this.pictureBox1.Top = rnd.Next(600);
            this.pictureBox1.Left = rnd.Next(950);
        }
    }
}
