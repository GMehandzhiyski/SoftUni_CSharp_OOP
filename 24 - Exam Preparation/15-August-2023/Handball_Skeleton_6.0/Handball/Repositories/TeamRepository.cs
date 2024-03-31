using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handball.Models.Contracts;
using Handball.Repositories.Contracts;

namespace Handball.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private List<ITeam> teams;


        public TeamRepository()
        {
            teams = new List<ITeam>();
        }
        public IReadOnlyCollection<ITeam> Models => teams;

        public void AddModel(ITeam model)
        {
           teams.Add(model);    
          
        }
        public bool RemoveModel(string name)
        {
            bool result = teams.Remove(teams.FirstOrDefault(t => t.Name == name));
            return result;
        }

        public bool ExistsModel(string name)
        {
            bool result = teams.Any(t => t.Name == name);
            return result;
        }

        public ITeam GetModel(string name)
        {
            var result = teams.FirstOrDefault(t => t.Name == name);
            return result;
        }

    }
}
