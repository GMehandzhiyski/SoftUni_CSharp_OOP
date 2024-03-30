using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handball.Models.Contracts;
using Handball.Repositories.Contracts;

namespace Handball.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        public IReadOnlyCollection<IPlayer> Models => throw new NotImplementedException();

        public void AddModel(IPlayer model)
        {
            throw new NotImplementedException();
        }

        public bool ExistsModel(string name)
        {
            throw new NotImplementedException();
        }

        public IPlayer GetModel(string name)
        {
            throw new NotImplementedException();
        }

        public bool RemoveModel(string name)
        {
            throw new NotImplementedException();
        }
    }
}
