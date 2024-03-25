using System.Runtime.CompilerServices;
using FoodShortage.Models;

namespace FoodShortage
{
    internal class StratUp
    {
        static void Main(string[] args)
        {
            List<Citizen> citizens = new List<Citizen>();
            List<Rebel> rebels = new List<Rebel>();

            int players = int.Parse(Console.ReadLine());

            for (int i = 0; i < players; i++) 
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                AddPeople(tokens, citizens, rebels);
            }
            
            string peopleName = string.Empty;
            while ((peopleName = Console.ReadLine()) != "End") 
            {
                AddFood(peopleName, citizens, rebels);
            }

           int citizensSum = citizens.Sum(p => p.Food);
           int rebelsSum = rebels.Sum(p => p.Food);

            Console.WriteLine(citizensSum + rebelsSum);
        }

        private static void AddFood(string peopleName, List<Citizen> citizens, List<Rebel> rebels)
        {
            if (citizens.Any(p => p.Name == peopleName))
            {
                citizens.First(p => p.Name == peopleName).BuyFood();
                
            }
            if (rebels.Any(p => p.Name == peopleName))
            {
                rebels.First(p => p.Name == peopleName).BuyFood();
            }
        }

        private static void AddPeople(string[] tokens, List<Citizen> citizens, List<Rebel> rebels)
        {
            if (tokens.Length == 4)
            {
              Citizen citizen = new(tokens[0], int.Parse(tokens[1]), (tokens[2]), tokens[3] );
              citizens.Add(citizen);
            }
            else 
            {
               Rebel rebel = new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]);
                rebels.Add(rebel);
            }
        }
    }
}
