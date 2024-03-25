using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        public void AddNew(ISupplement model)
        {
            throw new NotImplementedException();
        }

        public ISupplement FindByStandard(int interfaceStandard)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<ISupplement> Models()
        {
            throw new NotImplementedException();
        }

        public bool RemoveByName(string typeName)
        {
            throw new NotImplementedException();
        }
    }
}
