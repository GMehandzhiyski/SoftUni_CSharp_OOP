using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;

namespace UniversityCompetition.Models
{
    public abstract class Subject : ISubject
    {
        public int Id => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public double Rate => throw new NotImplementedException();
    }
}
