using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Repositories
{
    public class ClimberRepository : IRepository<IClimber>
    {
        public IReadOnlyCollection<IClimber> All => throw new NotImplementedException();

        public void Add(IClimber model)
        {
            throw new NotImplementedException();
        }

        public IClimber Get(string name)
        {
            throw new NotImplementedException();
        }
    }
}
