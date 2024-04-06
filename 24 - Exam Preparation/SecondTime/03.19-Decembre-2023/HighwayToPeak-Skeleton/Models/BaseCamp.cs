using HighwayToPeak.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
    public class BaseCamp : IBaseCamp
    {
        public IReadOnlyCollection<string> Residents => throw new NotImplementedException();

        public void ArriveAtCamp(string climberName)
        {
            throw new NotImplementedException();
        }

        public void LeaveCamp(string climberName)
        {
            throw new NotImplementedException();
        }
    }
}
