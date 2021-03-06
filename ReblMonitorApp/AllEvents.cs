using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using System.Text;

namespace ReblMonitorApp
{
    public static class AllEvents
    {
        [FunctionName("AllEvents")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)]HttpRequestMessage req
            , [Table("ReblEvents")] CloudTable reblEventsTable
            , TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            var events = from res in reblEventsTable.ExecuteQuery(new TableQuery<ReblEventStore>())
                select new ReblEvent()
                {
                    BusinessProcess = res.BusinessProcess
                    ,
                    StatusMessage = res.StatusMessage
                    ,
                    DisplayColour = res.DisplayColour
                    ,
                    When = res.When
                };

            var jsonToReturn = JsonConvert.SerializeObject(events);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json")
            };

        }
    }
}
