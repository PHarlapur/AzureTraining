using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure;
using System.Configuration;



using Microsoft.WindowsAzure.Storage.Queue;



namespace AzureStorageTable
{
    class Program
    {
        static void Main(string[] args)
        {

            var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);

            //CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            //CloudTable table = tableClient.GetTableReference("customers");
            //table.CreateIfNotExists();


            //Tables

            //CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            //CloudTable table = tableClient.GetTableReference("orders");
            //table.CreateIfNotExists();
            //OrderEntity newOrder = new OrderEntity("Archer", "20160119");
            //newOrder.OrderNumber = "101";
            //newOrder.Status = "shipped";
            //TableOperation insertOperation = TableOperation.Insert(newOrder);
            //table.Execute(insertOperation);

            //Queues.


            //Get a reference to the Queue client
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            //Get a reference to a Queue object
            CloudQueue queue = queueClient.GetQueueReference("prabhas-queue");
            queue.CreateIfNotExists();


            CloudQueueMessage message = new CloudQueueMessage("Message #1");
            queue.AddMessage(message);
            queue.AddMessage(new CloudQueueMessage("Message #2"));
            queue.AddMessage(new CloudQueueMessage("Message #3"));

           

            queue.DeleteMessage(message);



        }
    }
}
