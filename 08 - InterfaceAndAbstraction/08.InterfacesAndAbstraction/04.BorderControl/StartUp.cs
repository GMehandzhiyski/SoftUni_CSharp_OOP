using System.Diagnostics.Metrics;
using BorderControl.Models;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> detainedPerson = new List<string>();

            string tokens = string.Empty;
            BoarderControl boarder = new BoarderControl();


            while ((tokens = Console.ReadLine()) != "End")
            {
                string[] token = tokens
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (token.Length == 2)
                {
                    Robot robot = new(token[0], token[1]);
                    boarder.AddNumber(robot);
                }
                else if(token.Length == 3)
                {
                   Citizen citizen = new(token[0], int.Parse(token[1]), token[2]);
                    boarder.AddNumber(citizen);
                }
            }

            string fakeNumber = Console.ReadLine();

            var finalLisFakeNumbers = boarder.Numbers
                 .Where(n => n.Id.EndsWith(fakeNumber));

            foreach (var number in finalLisFakeNumbers)
            {
                Console.WriteLine(number.Id);
            }


        }
    }
}
