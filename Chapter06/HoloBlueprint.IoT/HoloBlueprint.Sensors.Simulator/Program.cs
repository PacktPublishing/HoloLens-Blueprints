namespace HoloBlueprint.Sensors.Simulator
{
    using HoloBlueprint.Data;
    using Microsoft.Azure.EventHubs;
    using System;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Simulator class
    /// </summary>
    class Program
    {
        private const string EhConnectionString = "Endpoint=sb://holoblueprinteventhub.servicebus.windows.net/;SharedAccessKeyName=all;SharedAccessKey=/xto4321wi4liOx+2Ox/ztxmAcaleczoioR/TUzD7k4=;EntityPath=holoblueprintsensoreventhub";
        private const string EhEntityPath = "holoblueprintsensoreventhub";

        static void Main(string[] args)
        {
            SendMessagesToEventHub(1000).Wait();
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        private static async Task SendMessagesToEventHub(int numMessagesToSend)
        {
            var connectionStringBuilder = new EventHubsConnectionStringBuilder(EhConnectionString)
            {
                EntityPath = EhEntityPath
            };

            var eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());

            Building building = BuildingCreator.LoadBuildingsData(0);

            for (var i = 0; i < numMessagesToSend; i++)
            {
                try
                {
                    var message = $"Message {i}";
                    Console.WriteLine($"Sending message: {message}");
                    await eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(building))));
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"{DateTime.Now} > Exception: {exception.Message}");
                }

                await Task.Delay(1000);
            }

            Console.WriteLine($"{numMessagesToSend} messages sent.");
        }
    }
}
