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
            label.ForeColor = Color.Blue;
            label.Location = new Point(700 - message.Length * 8, PanelMessage.id++ * PanelMessage.height);
            return label;
        }
    }
}
