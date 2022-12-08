﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSGuru
{
    internal class LocalAi: AiBot
    {
        private static string localHost = "http://127.0.0.1:5000/";
        public string getResponse(string message)
        {
            Thread.Sleep(1000);
            return callPython(message);
        }

        private static string callPython(string question)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), LocalAi.localHost + question))
                    {
                        var response = httpClient.SendAsync(request).Result;
                        var json = response.Content.ReadAsStringAsync().Result;
                        dynamic dynObj = JsonConvert.DeserializeObject(json);
                        if (dynObj != null)
                        {
                            return dynObj;
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

        private static string callPythonScript(string question)
        {
            //string cmdArguments = "/c \"python " + "C:\\Users\\sergey.adamyan\\PycharmProjects\\AIChatbot\\chabnot.py" + " " + question + "\"";

            //ProcessStartInfo start = new ProcessStartInfo();
            //start.FileName = "cmd.exe";
            //start.Arguments = cmdArguments;
            //start.RedirectStandardOutput = true;// Any output, generated by application will be redirected back
            //start.RedirectStandardError = true; // Any error in standard output will be redirected back (for example exceptions)
            //string errors = "";
            //string result = "";
            //using (Process process = Process.Start(start))
            //{
            //    errors = process.StandardError.ReadToEnd();
            //    result = process.StandardOutput.ReadToEnd();
            //}
            var script = "chatbot.py";
            var process = new System.Diagnostics.Process();
            var startInfo = new System.Diagnostics.ProcessStartInfo
            {
                WorkingDirectory = @"C:\Users\sergey.adamyan\PycharmProjects\AIChatbot",
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal,
                FileName = "cmd.exe",
                RedirectStandardInput = true,
                UseShellExecute = false,
                Arguments = $"python {script} "
            };
            process.StartInfo = startInfo;
            process.Start();

            //ProcessStartInfo psi = new ProcessStartInfo();
            //psi.FileName = @"C:\Users\sergey.adamyan\PycharmProjects\pythonProject\venv\Scripts\python.exe";

            //string script = @"C:\Users\sergey.adamyan\PycharmProjects\AIChatbot\chatbot.py";
            //psi.Arguments = $"\"{script}\" \"{question}\"";

            //psi.UseShellExecute = false;
            //psi.CreateNoWindow = true;
            //psi.RedirectStandardError = true;
            //psi.RedirectStandardOutput = true;

            //string errors = "";
            //string result = "";
            //using (Process process = Process.Start(psi))
            //{
            //    Thread.Sleep(2000);
            //    errors = process.StandardError.ReadToEnd();
            //    result = process.StandardOutput.ReadToEnd();
            //}
            return "";
        }
    }
}