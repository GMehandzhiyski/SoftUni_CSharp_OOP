

using _03.Raiding.Core.Interface;
using _03.Raiding.IO.Interfaces;

namespace _03.Raiding.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
     
        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;

        }
        public void Run()
        {


                // business Logic


        }
    }
}

