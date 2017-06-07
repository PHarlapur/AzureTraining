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
            //Service Bus Queue Sender
            var queueClient = QueueClient.CreateFromConnectionString(ConnectionString, QueuePath);
            for (int i = 0; i < 10; i++)
            {
                var message = new BrokeredMessage("Sender's Message ==> " + i);
                queueClient.Send(message);
                Console.Write("\nSent Message : = " + i);
            }

            Console.WriteLine("Press Enter to Exit...");
            Console.ReadLine();
            queueClient.Close();

        }


    }

}
