using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03.Raiding.IO.Interfaces;


namespace _03.Raiding.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(object str)
            => Console.WriteLine(str);  
    }
}
