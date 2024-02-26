using System;

namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Gorilla goo = new("Pesho");
            Console.WriteLine(goo.Name);
        }
    }
}