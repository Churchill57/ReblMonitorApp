using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using System.Threading.Tasks;

namespace ReblMonitorApp
{
    public static class StoreEvent
    {
        [FunctionName("StoreEvent")]
        [return: Table("ReblEvents")]
        public static async Task<ReblEventStore> Run(
            [QueueTrigger("reblmonitorqueue")]ReblEvent reblEvent
            , TraceWriter log)
        {
            log.Info($"C# Queue trigger function processed: {reblEvent.BusinessProcess} {reblEvent.StatusMessage} {reblEvent.DisplayColour}");
            var reblEventStore = new ReblEventStore()
            {
                PartitionKey = reblEvent.BusinessProcess,
                RowKey = Guid.NewGuid().ToString(),
                BusinessProcess = reblEvent.BusinessProcess,
                StatusMessage = reblEvent.StatusMessage,
                DisplayColour = reblEvent.DisplayColour,
                When = reblEvent.When
            };
            return reblEventStore;
        }
    }
}
