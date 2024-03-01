
using System;
using System.Net.Security;
using ShoppingSpree.Model;

namespace ShoppingSpree
{
    public class Program
    {
            
        static void Main(string[] args)
        {
            List<Person> peoples = new List<Person>();
            List<Product> products = new List<Product>();

           

            try
            {
                peoples = Console.ReadLine().Split(';',StringSplitOptions.RemoveEmptyEntries).ToList()
                 .Select(t => t.Split('='))
                 .Select(p => new Person(p[0], decimal.Parse(p[1])))
                 .ToList();

                products = Console.ReadLine().Split(new[] { ';' },StringSplitOptions.RemoveEmptyEntries).ToList()
                 .Select(t => t.Split('='))
                 .Select(p => new Product(p[0], decimal.Parse(p[1])))
                 .ToList();

                string tokens = string.Empty;

                while ((tokens = Console.ReadLine()) != "END")
                {
                    string[] arguments = tokens
                        .Split(" ");

                    Person person = peoples.First(p => p.Name == arguments[0]);
                    Product product = products.First(p => p.Name == arguments[1]);

                    Console.WriteLine(person.AddProductToBag(product));
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return;
            }

          

            peoples.ForEach(p => Console.WriteLine(p));
        }
    }
}
