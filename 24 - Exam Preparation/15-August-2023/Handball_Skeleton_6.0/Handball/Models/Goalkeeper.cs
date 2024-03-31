using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class Goalkeeper : Player
    {
        private const double GoalkeeperRating = 2.5;
        public Goalkeeper(string name)
            : base(name, GoalkeeperRating)
        {
        }
        public override void IncreaseRating()
        {
         
            Rating += 0.75;
        }

        public override void DecreaseRating()
        {
            Rating -= 1.25;
        }

    }
}
