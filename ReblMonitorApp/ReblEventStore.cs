using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace ReblMonitorApp
{
    public class ReblEventStore : TableEntity
    {
        //public string PartitionKey { get; set; } - BusinessProcess
        //public string RowKey { get; set; } - When

        public string BusinessProcess { get; set; }
        public string StatusMessage { get; set; }
        public int DisplayColour { get; set; }
        public DateTime When { get; set; }

    }
}
