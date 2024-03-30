using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class Goalkeeper : Player
    {
        public Goalkeeper(string name, double rating)
            : base(name, rating)
        {
        }
    }
}
