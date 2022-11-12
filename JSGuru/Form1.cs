using Newtonsoft.Json;
using System.Diagnostics;
using System.Globalization;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace JSGuru
{
    public partial class Form1 : Form
    {
        PanelMessage question = new Question();
        PanelMessage answer = new Answer();
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private static string callPythonScript(string question)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = @"C:\Users\User\AppData\Local\Programs\Python\Python311\python.exe";

            string script = @"C:\Scripts\script.py";
            psi.Arguments = $"\"{script}\" \"{question}\"";

            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardError = true;
            psi.RedirectStandardOutput = true;

            string errors = "";
            string result = "";
            using (Process process = Process.Start(psi))
            {
                errors = process.StandardError.ReadToEnd();
                result = process.StandardOutput.ReadToEnd();
            }
            return result;
        }
        private static string callOpenAI(int tokens, string input, string engine, double temperature, int topP, double frequencyPenalty, double presencePenalty)
        {
            string openAiKey = "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";

            var apiCall = "https://api.openai.com/v1/engines/" + engine + "/completions";
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), apiCall))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + openAiKey);
                        request.Content = new StringContent("{\n  \"prompt\": \"" + input + "\",\n  \"temperature\": " +
                                                            temperature.ToString(CultureInfo.InvariantCulture) + ",\n  \"max_tokens\": " + tokens + ",\n  \"top_p\": " + topP +
                                                            ",\n  \"frequency_penalty\": " + frequencyPenalty + ",\n  \"presence_penalty\": " + presencePenalty + "\n}");
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                        var response = httpClient.SendAsync(request).Result;
                        var json = response.Content.ReadAsStringAsync().Result;
                        dynamic dynObj = JsonConvert.DeserializeObject(json);
                        if (dynObj != null)
                        {
                            return dynObj.choices[0].text.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;

        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string question = this.textBoxQuestion.Text;
                this.panel.Controls.Add(this.question.GetMessage(question));
                //var answer = callOpenAI(250, question, "text-davinci-002", 0.7, 1, 1, 0).Trim('\n');
                var answer = callPythonScript(question);
                this.panel.Controls.Add(this.answer.GetMessage(answer));
            }
        }
    }
}