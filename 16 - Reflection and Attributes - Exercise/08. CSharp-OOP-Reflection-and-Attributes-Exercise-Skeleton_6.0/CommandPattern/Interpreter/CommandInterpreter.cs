using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Interpreter
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] elements = args
                .Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
            string command = $"{elements[0]}Command";
            var commandsArgs = elements.Skip(1).ToArray();


            var assembly = Assembly.GetEntryAssembly();

      
            Type types = assembly?.GetTypes()
                .FirstOrDefault(a => a.Name == command);

           if (types == null) 
            {
                throw new ArgumentException("Invalid type!");
            }

            var instance =(ICommand)Activator.CreateInstance(types);
             return instance?.Execute(commandsArgs);

       
        }   
    }
}