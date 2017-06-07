using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;


namespace AzureServiceBus
{
    class Program
    {
        static string ConnectionString = "Endpoint=sb://prabhas-servicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=+F7V1AUC/vqSuZc/cMCAqoNj4sNwAPY70+rQ7yyAn/k=";
        static string TopicPath = "subtopics";

        static void Main(string[] args)
        {
            Console.WriteLine("Enter Name - ");
            var username = Console.ReadLine();

            var manager = NamespaceManager.CreateFromConnectionString(ConnectionString);
            if (!manager.TopicExists(TopicPath))
            {
                manager.CreateTopic(TopicPath);
            }
            var description = new SubscriptionDescription(TopicPath, username);
            {
                description.AutoDeleteOnIdle = TimeSpan.FromMinutes(5);
            }
            manager.CreateSubscription(description);

            var factory = MessagingFactory.CreateFromConnectionString(ConnectionString);
            var topicClient = factory.CreateTopicClient(TopicPath);
            var subscriptionClient = factory.CreateSubscriptionClient(TopicPath, username);

            subscriptionClient.OnMessage(msg => ProcessMessage(msg));
            var hellomessage = new BrokeredMessage("Has entered the Room...");
            hellomessage.Label = username;
            topicClient.Send(hellomessage);
            while (true)
            {
                string text = Console.ReadLine();
                if (text.Equals("exit")) break;
                var chatMessage = new BrokeredMessage(text);
                chatMessage.Label = username;
                topicClient.Send(chatMessage);
            }

            var goodbyeMessage = new BrokeredMessage("Has left the building.....");
            goodbyeMessage.Label = username;
            topicClient.Send(goodbyeMessage);
            factory.Close();
        }


        static void ProcessMessage(BrokeredMessage message)
        {
            string user = message.Label;
            string text = message.GetBody<string>();
            Console.WriteLine(user + ">" + text);
        }
    }

}
