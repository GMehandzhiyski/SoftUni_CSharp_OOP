namespace HighwayToPeak.Models
{
    using HighwayToPeak.Models.Contracts;
    using HighwayToPeak.Utilities.Messages;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Climber : IClimber
    {
        private string name;
        private int stamina;
        private List<string> conqueredPeaks;

        protected Climber(string name, int stamina)
        {
            Name = name;
            Stamina = stamina;
            this.conqueredPeaks = new List<string>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ClimberNameNullOrWhiteSpace);
                }
                name = value;
            }
        }

        public int Stamina
        {
            get => stamina;
            protected set
            {
                if (value < 0)
                {
                    stamina = 0;
                }
                else if (value > 10)
                {
                    stamina = 10;
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
                this.conqueredPeaks.Add(peak.Name);
            }            

            int tempStamina = 0;

            if (peak.DifficultyLevel == "Extreme")
            {
                tempStamina += 6;
            }
            else if(peak.DifficultyLevel == "Hard")
            {
                tempStamina += 4;
            }
            else
            {
                tempStamina += 2;
            }

            this.Stamina -= tempStamina;
        }

        public abstract void Rest(int daysCount);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name} - Name: {Name}, Stamina: {Stamina}");
            sb.Append("Peaks conquered: ");

            if(this.conqueredPeaks.Count > 0)
            {
                sb.AppendLine($"{ConqueredPeaks.Count}");
            }
            else
            {
                sb.Append("no peaks conquered");
            }

            return sb.ToString().Trim();
        }
    }
}
