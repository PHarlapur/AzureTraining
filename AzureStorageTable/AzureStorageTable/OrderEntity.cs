using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;


namespace AzureStorageTable
{
    public class OrderEntity : TableEntity
    {
        public OrderEntity(string customerName, String orderDate)
        {
            this.PartitionKey = customerName;
            this.RowKey = orderDate;
        }
        public OrderEntity() { }
        public string OrderNumber { get; set; }
        public string Status { get; set; }
    }

}
