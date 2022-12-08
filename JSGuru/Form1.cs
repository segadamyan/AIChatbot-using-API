using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Globalization;
using System.Media;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace JSGuru
{
    public partial class Form1 : Form
    {
        PanelMessage question = new Question();
        PanelMessage answer = new Answer();
        private SoundPlayer send = new SoundPlayer();
        private SoundPlayer receive = new SoundPlayer();
        AiBot bot = new OpenAiConv();

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            send.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "send.wav";
            receive.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "receive.wav";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string question = this.textBoxQuestion.Text;
                this.textBoxQuestion.Text = "";
                this.panel.Controls.Clear();
                this.panel.Controls.Add(this.question.GetMessage(question));
                this.send.Play();
                string answer = bot.getResponse(question);
                this.panel.Controls.Add(this.answer.GetMessage(answer));
                this.receive.Play();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}