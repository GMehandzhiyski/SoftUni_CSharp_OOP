using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class SubjectRepository : IRepository<ISubject>
    {
        public IReadOnlyCollection<ISubject> Models => throw new NotImplementedException();

        public void AddModel(ISubject model)
        {
            throw new NotImplementedException();
        }

        public ISubject FindById(int id)
        {
            throw new NotImplementedException();
        }

        public ISubject FindByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
