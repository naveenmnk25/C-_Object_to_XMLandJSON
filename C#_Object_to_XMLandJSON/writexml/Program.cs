using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Serialization;
using static writexml.Program;

namespace writexml
{
    public static class ProductExtension //Extension method
    {
        public static void Convert2Xml(this Product product)
        {
            string file = $"D:\\xmlfile\\{product.Name}.xml";
            new XmlSerialize().ConvertSingleObjiectToXml(product, file, true);
        }
    }
    public static class ProductExtensionJson
    {
        public static void Convert2Json(this Product product)
        {
            var customerJson = JsonConvert.SerializeObject(product);
            //Console.WriteLine(customerJson);

            using (TextWriter writer = File.CreateText($"D:\\xmlfile\\{product.Name}-Json.json"))
            {
                writer.WriteLine(customerJson);

            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 10; i++)
            {
                Product product = new Product
                {
                    Name = "t-Shirt-" + i.ToString(),
                    Price = 250,
                    Unit = 100,
                    Year = 2022,
                    Buyername = "Naveenkumar m",
                    Category = new Category(1, "Sports"),
                    Colors = new List<Color>() { new Color { Id = 1, Name = "Black" }, new Color { Id = 2, Name = "Blue" } }
                };
                product.Convert2Xml();
                product.Convert2Json();
            }
           
        }
           
        public class Product
        {
            public string Name { get; set; }
            public int Unit { get; set; }
            public double Price { get; set; }
            public int Year { get; set; }
            public string Buyername { get; set; }
            public Category Category { get; set; }
            public List<Color> Colors { get; set; }
        }

        public class Category
        {
            public Category()
            {

            }

            public Category(int Id, string Name)
            {
                this.Id = Id;
                this.Name = Name;
            }

            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class Color
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class XmlSerialize   
        {
            public void ConvertSingleObjiectToXml<T>(T obj, string file, bool overwrite)
            {
                bool append = !overwrite;
                using (StreamWriter writer = new StreamWriter(file, append, Encoding.UTF8))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(writer, obj);       
                }
            }
        }
    }
}
    