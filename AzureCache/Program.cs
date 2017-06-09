using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureCache
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionMultiplexer connection = ConnectionMultiplexer.Connect("prabhas-cache.redis.cache.windows.net:6380,password=xnpktiMq6vODUEmUlT51ZW8etP2BevvoMFwKtFZtNjE=,ssl=True,abortConnect=False");


            IDatabase cache = connection.GetDatabase();

            string key1 = "key1";
            string key2 = "key2";

            int value1 = 20;
            string value2 = "Tomesh";

            if (cache.StringGet(key1).IsNull)
            {
                Console.WriteLine(key1 + " is not found in the cache");
                Console.WriteLine("Putting " + key1 + "into cache with value " + value1);
                cache.StringSet(key1, value1);
            }
            else
            {
                Console.WriteLine(key1 + " is found in the cache");
            }
            if (cache.StringGet(key2).IsNull)
            {
                Console.WriteLine(key2 + " is found in the cache");
                Console.WriteLine("Putting " + key2 + "into cache with value " + value2);
                cache.StringSet(key2, value2);
            }
            else
            {
                Console.WriteLine(key2 + " is found in the cache");
            }
            Console.WriteLine(key1 + " : " + cache.StringGet(key1));
            Console.WriteLine(key2 + " : " + cache.StringGet(key2));

            Person p = new Person("Hemant", "Vijay", "Jaipur");

            var serialzedobj = JsonConvert.SerializeObject(p);
            if (cache.StringGet("key3").IsNull)
            {
                Console.WriteLine("Putting Person Object into the cache");
                cache.StringSet("key3", serialzedobj);
            }
            else
            {
                Console.WriteLine("Person Object found in the cache");
            }

            Console.WriteLine("Retrieving Person details from cache");
            Person person = JsonConvert.DeserializeObject<Person>(cache.StringGet("key3"));

            person.printDetails();

            Console.ReadLine();

        }
    }
}
