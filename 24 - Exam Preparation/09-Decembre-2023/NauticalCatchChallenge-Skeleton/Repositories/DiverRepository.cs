﻿
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Repositories
{
    public class DiverRepository : IRepository<IDiver>
    {
        private List<IDiver> divers;
        public DiverRepository()
        {
            divers = new List<IDiver>();
        }


        public IReadOnlyCollection<IDiver> Models => divers.AsReadOnly();

        public void AddModel(IDiver diver)
        {
           divers.Add(diver);
        }

        public IDiver GetModel(string name)
        {
            return divers.FirstOrDefault(d => d.Name == name);
        }
    }
}
