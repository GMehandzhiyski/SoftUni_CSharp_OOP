using System;

namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Cake cake = new("Nini");

            Console.WriteLine(cake.Name);
            Console.WriteLine(cake.Grams);
            Console.WriteLine(cake.Calories);
            Console.WriteLine(cake.Price);

        }
    }
}