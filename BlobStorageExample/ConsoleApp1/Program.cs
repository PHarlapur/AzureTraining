using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            //Retrieve Storage account from connection string
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);

            //Create the blob client
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            //Retrieve a reference to a container
            CloudBlobContainer container = blobClient.GetContainerReference("prabhas-container");

            //Create the container if it doesn't already exist
            container.CreateIfNotExists();

            //Retrieve reference to a blob named "storageblob"
            CloudBlockBlob blockBlob = container.GetBlockBlobReference("BlobFile.txt");

            //Create or overwrite the "storageblob" blob with contents from a local file
            using (var filestream = System.IO.File.OpenRead(@"C:\azure\BlobFile.txt"))
            {
                blockBlob.UploadFromStream(filestream);
            }

        }
    }
}
