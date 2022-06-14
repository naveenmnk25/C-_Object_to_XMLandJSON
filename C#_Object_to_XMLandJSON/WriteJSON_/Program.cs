using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace jsontoobj
{
    public class Program
    {
        static void Main(string[] args)
        {
            var customers = new List<customer>
            {
                new customer
                {
                    Name ="Naveenkumar M",
                    Age=22,
                    Email="naveen@gmail.com"
                } ,
                new customer
                {
                    Name ="Sathishkumar M",
                    Age=20,
                    Email="Sathishkumar@gmail.com"
                },
                new customer
                {
                    Name ="vignesh M",
                    Age=21,
                    Email="vignesh@gmail.com"
                }
            };
            var customerJson = JsonConvert.SerializeObject(customers);
            Console.WriteLine(customerJson);

            using (TextWriter writer = File.CreateText(@"D:\xmlfile\jsonfileseriali.json"))
            {
                writer.WriteLine(customerJson);

            }
            Console.ReadKey();
        }
    }
    [Serializable]
    public class customer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

    }
}




//////////
///

/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
namespace WriteJSON_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            person person = new person() { UserName = "Naveenkumar M", userID = 045, Address = "Madurai 625503" };

            var jsonPerson = JsonConvert.SerializeObject(person);

         *//*   Console.Write("Json : ");
            Console.WriteLine(jsonPerson);*//*

            using (TextWriter writer = File.CreateText("D:\\xmlfile\\jsonfile.json"))
            {
                writer.WriteLine(jsonPerson);
                
            }
        }
    }
    public class person
    {
        public string UserName { get; set; }
        public int userID { get; set; }
        public string Address { get; set; }
    }
}*/
