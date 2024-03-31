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
        private List<IPlayer> players;

        public PlayerRepository()
        {
            players = new List<IPlayer>();
        }
        public IReadOnlyCollection<IPlayer> Models => players;

        public void AddModel(IPlayer model)
        {
           players.Add(model);
        }
        public bool RemoveModel(string name)
        {
           bool result = players.Remove(players.FirstOrDefault(p => p.Name == name));
            return result;
        }

        public bool ExistsModel(string name)
        {
            bool result = players.Any(p => p.Name == name);
            return result;
        }

        public IPlayer GetModel(string name)
        {
            var result = players.FirstOrDefault(p => p.Name == name);   
            return result;
        }

    }
}
