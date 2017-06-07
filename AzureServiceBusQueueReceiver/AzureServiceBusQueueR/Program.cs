using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.ServiceBus.Messaging;

namespace AzureServiceBusQueue
{

    class Program
    {

        static string ConnectionString = "Endpoint=sb://prabhas-servicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=+F7V1AUC/vqSuZc/cMCAqoNj4sNwAPY70+rQ7yyAn/k=";
        static string QueuePath = "sbqueue";

        static void Main(string[] args)
        {
            //Service Bus Queue Receiver
            var queueClient = QueueClient.CreateFromConnectionString(ConnectionString, QueuePath);

            queueClient.OnMessage(msg => ProcessMessage(msg));

            Console.WriteLine("Press Enter to Exit...");
            Console.ReadLine();

            queueClient.Close();
        }

        private static void ProcessMessage(BrokeredMessage msg)
        {
            var text = msg.GetBody<string>();
            Console.WriteLine("\nReceived Messages : " + text);
        }


    }

}
