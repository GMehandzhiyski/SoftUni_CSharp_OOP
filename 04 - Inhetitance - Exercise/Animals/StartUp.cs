using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string tokens = string.Empty;
            try
            {
                while ((tokens = Console.ReadLine()) != "Beast!")
                {
                    string[] argumets = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    //Animal animal = new Animal();   

                    if (tokens == "Dog")
                    {
                        Dog dog = new(argumets[0], int.Parse(argumets[1]), argumets[2]);
                        Console.WriteLine(tokens);
                        Console.WriteLine(dog.ToString());
                    }

                    else if (tokens == "Cat")
                    {
                        Cat cat = new(argumets[0], int.Parse(argumets[1]), argumets[2]);
                        Console.WriteLine(tokens);
                        Console.WriteLine(cat.ToString());

                    }

                    else if (tokens == "Frog")
                    {
                        Frog frog = new(argumets[0], int.Parse(argumets[1]), argumets[2]);
                        Console.WriteLine(tokens);
                        Console.WriteLine(frog.ToString());
                    }

                    else if (tokens == "Kitten")
                    {
                        Kitten kitten = new(argumets[0], int.Parse(argumets[1]));
                        Console.WriteLine(tokens);
                        Console.WriteLine(kitten.ToString());
                    }

                    else if (tokens == "Tomcat")
                    {
                        Tomcat tomcat = new(argumets[0], int.Parse(argumets[1]));
                        Console.WriteLine(tokens);
                        Console.WriteLine(tomcat.ToString());
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            
        }
    }
}
