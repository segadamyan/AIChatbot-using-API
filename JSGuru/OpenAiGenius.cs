using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSGuru
{
    internal class OpenAiGenius : AiBot
    {
        public string getResponse(string message)
        {
            return AiBot.callOpenAI(250, message, "text-davinci-002", 0.7, 1, 1, 0).Trim('\n');
        }
    }
}
