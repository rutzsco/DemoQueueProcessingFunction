using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.ServiceBus.Messaging;

namespace DemoQueueProcessig
{
    public static class Function3
    {
        [FunctionName("Function3")]
        public static void Run([ServiceBusTrigger("myqueue3", AccessRights.Manage, Connection = "ServiceBusConnectionString")]string myQueueItem, TraceWriter log)
        {
            log.Info($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
