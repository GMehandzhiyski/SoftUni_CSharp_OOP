using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Engines
{
    public class Engine : IEngine 
    {
        private readonly ICommandInterpreter commandInterpreter;
        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            while (true)
            {
                string inputString = Console.ReadLine();
                string result = String.Empty;
                try
                {
                    result = commandInterpreter.Read(inputString);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine(result);


            }
        }
    }
}
