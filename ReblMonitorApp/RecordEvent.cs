using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace ReblMonitorApp
{
    public static class RecordEvent
    {
        [FunctionName("RecordEvent")]
        [return: Queue("reblmonitorqueue")]
        public static async Task<ReblEvent> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]HttpRequestMessage req
            , TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");
            ReblEvent reblEvent = await req.Content.ReadAsAsync<ReblEvent>();
            reblEvent.When = DateTime.Now;
            log.Info($"Event received: {reblEvent.BusinessProcess} {reblEvent.StatusMessage} {reblEvent.DisplayColour}");
            return reblEvent;
        }
    }
}
