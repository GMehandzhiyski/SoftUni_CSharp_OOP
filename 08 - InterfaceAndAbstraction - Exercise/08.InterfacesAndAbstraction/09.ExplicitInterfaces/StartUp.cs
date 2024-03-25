using System.Security.Cryptography.X509Certificates;
using ExplicitInterfaces.Models;
using ExplicitInterfaces.Models.Interfaces;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string tokens = string.Empty;
            while ((tokens = Console.ReadLine())!= "End")
            {
                string[] token = tokens
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                IPerson citizenPerson = new Citizen(token[0], token[1], int.Parse(token[2]));
                IResident citizenResident = new Citizen(token[0], token[1], int.Parse(token[2]));

                Console.WriteLine(citizenPerson.GetName());
                Console.WriteLine(citizenResident.GetName());
            }
        }
    }
}
