using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class UniversityRepository : IRepository<IUniversity>
    {
        public IReadOnlyCollection<IUniversity> Models => throw new NotImplementedException();

        public void AddModel(IUniversity model)
        {
            throw new NotImplementedException();
        }

        public IUniversity FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IUniversity FindByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
