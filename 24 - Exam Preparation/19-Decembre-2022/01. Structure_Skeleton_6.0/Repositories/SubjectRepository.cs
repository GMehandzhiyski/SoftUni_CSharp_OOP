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
        private readonly List<ISubject> subjects;

        public SubjectRepository()
        {
            subjects = new List<ISubject>();
        }

        public void AddModel(ISubject model)
        {
            subjects.Add(model);
        }

        public ISubject FindById(int id)
        {
            return subjects.FirstOrDefault(m => m.Id == id);
        }

        public ISubject FindByName(string name)
        {
            return subjects.FirstOrDefault(m => m.Name == name);
        }
        public IReadOnlyCollection<ISubject> Models => subjects;
    }
}
