using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExplicitInterfaces.Models.Interfaces;

namespace ExplicitInterfaces.Models
{
    public class Citizen : IPerson, IResident
    {
        public string Name { get; }
        public string Country { get; }
        public int Age { get; }

        public Citizen(string name,string country, int age)
        {
            Name = name;
            Country = country;
            Age = age;
        }


        string IPerson.GetName()
        {
            return Name;
        }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {Name}";
        }
    }
}
