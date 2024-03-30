using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handball.Models.Contracts;

namespace Handball.Models
{
    public abstract class Player : IPlayer
    {
        protected Player(string name, double rating)
        {
        
        }
        public string Name => throw new NotImplementedException();

        public double Rating => throw new NotImplementedException();

        public string Team => throw new NotImplementedException();

        public void JoinTeam(string name)
        {
            throw new NotImplementedException();
        }
        public void IncreaseRating()
        {
            throw new NotImplementedException();
        }
        public void DecreaseRating()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "";
        }
    }
}
