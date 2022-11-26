using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSGuru
{
    internal interface PanelMessage
    {
        public static int id = 0;

        public static readonly int height = 20;

        public static readonly Font font = new Font("Calibri", 16);
        public Label GetMessage(string message);
    }
}
