﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
		private List<Person> firstTeam;
		private List<Person> secondTeam;
        public Team(string name)
        {
            this.name = name;
            firstTeam = new List<Person>();
            secondTeam = new List<Person>();    
            
        }
    
        public IReadOnlyCollection<Person> FirstTeam
		{
			get { return firstTeam.AsReadOnly(); }
		}
        public IReadOnlyCollection<Person> SecondTeam 
		{
            get { return secondTeam.AsReadOnly(); }
        }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            { 
             firstTeam.Add(person);
            }
            else
            {
                secondTeam.Add(person);
            }
        }
    }
}
