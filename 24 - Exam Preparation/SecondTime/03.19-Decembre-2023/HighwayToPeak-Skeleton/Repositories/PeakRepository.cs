using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Repositories
{
    public class PeakRepository : IRepository<IPeak>
    {
        public IReadOnlyCollection<IPeak> All => throw new NotImplementedException();

        public void Add(IPeak model)
        {
            throw new NotImplementedException();
        }

        public IPeak Get(string name)
        {
            throw new NotImplementedException();
        }
    }
}
