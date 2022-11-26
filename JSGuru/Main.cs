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
        public Main()
        {
            InitializeComponent();
            soundPlayer = new SoundPlayer();
            soundPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "robot-6282.wav";
            soundPlayer.Play();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            PanelMessage.id = 0;
            this.Hide();
            this.soundPlayer.Stop();
            form.ShowDialog();
            this.Show();
        }
    }
}
