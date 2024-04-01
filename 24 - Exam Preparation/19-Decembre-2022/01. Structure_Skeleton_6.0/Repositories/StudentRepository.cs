using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        public IReadOnlyCollection<IStudent> Models => throw new NotImplementedException();

        public void AddModel(IStudent model)
        {
            throw new NotImplementedException();
        }

        public IStudent FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IStudent FindByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
