using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSGuru
{
    internal class Answer: PanelMessage
    {
        public Label GetMessage(string message)
        {
            Label label = new Label();
            label.Location = new Point(10, PanelMessage.id++ * PanelMessage.height);
            if (message.Length > 150)
            {
                String[] splited = message.Split("\n");
                PanelMessage.id += splited.Length - 1;
            }
            label.Text = message;
            label.AutoSize = true;
            label.Font = PanelMessage.font;
            label.ForeColor = Color.Magenta;
            
            return label;
        }
    }
}
