using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSGuru
{
    internal class Question : PanelMessage
    {
        public Label GetMessage(string message)
        {
            Label label = new Label();
            label.Text = message;
            label.AutoSize = true;
            label.Font = PanelMessage.font;
            label.ForeColor = Color.White;
            //label.Location = new Point(700 - message.Length * 8, PanelMessage.row++ * PanelMessage.height);
            label.Location = new Point(10, 10);
            return label;
        }
    }
}
