using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        private string name;
        private int oxygenLevel;
        private List<string> catches;
        private double competitionPoints;
        private bool hasHealthIssues;

        public Diver(string name, int oxygenLevel)
        {
            Name = name;
            OxygenLevel = oxygenLevel;  
            competitionPoints = 0;
            hasHealthIssues = false;
            catches = new List<string>();
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DiversNameNull);
                }
                name = value;
            }
        }

        public int OxygenLevel
        {
            get { return oxygenLevel; }
            protected set
            {
                if (value < 0)
                {
                    oxygenLevel = 0;
                }
                else 
                {
                    oxygenLevel = value;
                }
               
            }
        }

        public IReadOnlyCollection<string> Catch => catches.AsReadOnly();

        public double CompetitionPoints
        {
            get { return Math.Round(competitionPoints, 1); }
            private set
            {
                competitionPoints = value;
            }
        }

        public bool HasHealthIssues
        {
            get { return hasHealthIssues; }
            private set
            {
                hasHealthIssues = value;
            }
        }

        public void Hit(IFish fish)
        {
            oxygenLevel -= fish.TimeToCatch;
            catches.Add(fish.Name);
            CompetitionPoints += fish.Points;
        }

        public abstract void Miss(int TimeToCatch);

        public abstract void RenewOxy();

        public void UpdateHealthStatus()
        {
            if (HasHealthIssues) 
            {
                HasHealthIssues = false;
            }
            else 
            {
                HasHealthIssues = true;
            }
        }

        public override string ToString()
        {
            
            return $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {catches.Count}, Points earned: {CompetitionPoints} ]";
        }
    }
}
