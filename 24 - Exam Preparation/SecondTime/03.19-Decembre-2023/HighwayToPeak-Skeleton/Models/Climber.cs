using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HighwayToPeak.Models
{
    public abstract class Climber : IClimber
    {
        private string name;
        private int stamina;
        private List<string> conqueredPeaks;


        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.ClimberNameNullOrWhiteSpace));
                }
                name = value;
            }
        }
        public int Stamina
        {
            get { return stamina; }
            private set
            {
                if (value > 10)
                {
                    stamina = 10;
                }
                else if (value < 0)
                {
                    stamina = 0;
                }
                else 
                {
                    stamina = value;
                }
                
            }
        }

        public IReadOnlyCollection<string> ConqueredPeaks => conqueredPeaks.AsReadOnly();

        public void Climb(IPeak peak)
        {
            if (!conqueredPeaks.Contains(peak.Name))
            {
                conqueredPeaks.Add(peak.Name);
            }

            if (peak.DifficultyLevel == "Extreme")
            {
                stamina -= 6;
            }
            else if (peak.DifficultyLevel == "Hard")
            {
                stamina -= 4;
            } 
            else if (peak.DifficultyLevel == "Moderate")
            {
                stamina -= 2;
            }
        }

        public abstract void Rest(int daysCount);


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{GetType().Name} - Name: {Name}, Stamina: {Stamina}");

            if (conqueredPeaks.Any())
            {
                sb.AppendLine($"{conqueredPeaks.Count}");
            }
            else
            {
                sb.AppendLine("Peaks conquered: no peaks conquered");
            }
           

            return sb.ToString().Trim();
        }
    }
}
