using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace JSGuru
{
    internal class OpenAiConv : AiBot
    {
        public string getResponse(string message)
        {
            return AiBot.callOpenAI(60, "You: " + message, "text-davinci-003", 0.5, 1, 0.5, 0).Trim('\n');
        }
    }
}
