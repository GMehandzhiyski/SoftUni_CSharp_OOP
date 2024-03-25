
using Telephony.Models.Interfaces;
using Telephony.Models;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] inputNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] inputUrl = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var number in inputNumbers)
            {

                if (number.Length <= 7)
                {
                    StationaryPhone phone = new StationaryPhone();
                    Console.WriteLine(phone.Call(number));
                }
                else
                {
                    SmartPhone phone = new SmartPhone();
                    Console.WriteLine(phone.Call(number));
                }

            }

            foreach (var currUrl in inputUrl)
            {
                SmartPhone phone = new SmartPhone();
                Console.WriteLine(phone.Browse(currUrl));
            }

        }
    }

}