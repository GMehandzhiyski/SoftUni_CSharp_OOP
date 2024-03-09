

using _03.Raiding.Core;
using _03.Raiding.Core.Interface;
using _03.Raiding.IO;
using _03.Raiding.IO.Interfaces;

namespace _03.Raiding
{
    internal class StartUP
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();


         
            IEngine engine = new Engine(reader, writer);

            engine.Run();
        }
    }
}
