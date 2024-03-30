using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Handball.Models.Contracts;

namespace Handball.Models
{
    public class Team : ITeam
    {
        public Team(string name)
        {
            
        }
        public string Name => throw new NotImplementedException();

        public int PointsEarned => throw new NotImplementedException();

        public double OverallRating => throw new NotImplementedException();

        public IReadOnlyCollection<IPlayer> Players => throw new NotImplementedException();

        public void SignContract(IPlayer player)
        {
            throw new NotImplementedException();
        }
        public void Win()
        {
            throw new NotImplementedException();
        }
        public void Lose()
        {
            throw new NotImplementedException();
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
