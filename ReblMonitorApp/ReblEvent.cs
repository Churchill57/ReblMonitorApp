using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReblMonitorApp
{
    public class ReblEvent
    {
        public string BusinessProcess { get; set; }
        public string StatusMessage { get; set; }
        public string DisplayColour { get; set; }
        public DateTime When { get; set; }
    }
}
