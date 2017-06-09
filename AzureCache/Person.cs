using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureCache
{
    public class Person
    {

        public Person(string fname, string lname, string city)
        {
            this.firstname = fname;
            this.lastname = lname;
            this.city = city;
        }

        public string firstname;
        public string lastname;
        public string city;

        public void printDetails()
        {
            Console.WriteLine("First Name : " + firstname);
            Console.WriteLine("Last Name : " + lastname);
            Console.WriteLine("City : " + city);
        }

    }
}
