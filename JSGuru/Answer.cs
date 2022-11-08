using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace JSGuru
{
    internal class Answer: PanelMessage
    {
        public Label GetMessage(string message)
        {
            Label label = new Label();
            label.Location = new Point(10, PanelMessage.id++ * PanelMessage.height);
            if (message.Length > 100)
            {
                message = message.Insert(100, "\n");
                PanelMessage.id++;
            }
            label.Text = message;
            label.AutoSize = true;
            label.Font = PanelMessage.font;
            label.ForeColor = Color.Red;
            

            return label;
        }
    }
}
