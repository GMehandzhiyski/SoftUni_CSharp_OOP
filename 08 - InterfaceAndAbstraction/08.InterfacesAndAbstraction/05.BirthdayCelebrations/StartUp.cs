

using BirthdayCelebrations.Models;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> detainedPerson = new List<string>();

            string tokens = string.Empty;

            Birthdate currBirthdates = new Birthdate(); 


            while ((tokens = Console.ReadLine()) != "End")
            {
                string[] token = tokens
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (token.Length == 3
                    && token[0] == "Robot") //  ROBOT
                {
                    Robot robot = new(token[1], token[2]);
                   
                }
                else if (token.Length == 5) // Citizen
                {
                    Citizen citizen = new(token[1], int.Parse(token[2]), token[3], token[4] );
                    currBirthdates.AddNumber(citizen);
                }
                else if(token.Length == 3
                    && token[0] == "Pet") //Pet
                {

                    Pet pet = new(token[1], token[2]);
                    currBirthdates.AddNumber(pet);
                }
            }

            string fakeNumber = Console.ReadLine();

            var finalLisFakeNumbers = currBirthdates.Birthdates
                 .Where(n => n.Birthdate.EndsWith(fakeNumber));

            if (!finalLisFakeNumbers.Any())
            {
                return;
            }
            foreach (var number in finalLisFakeNumbers)
            {
                Console.WriteLine(number.Birthdate);
            }


        }
    }
}
