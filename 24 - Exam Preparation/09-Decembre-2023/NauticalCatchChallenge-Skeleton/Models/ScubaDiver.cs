using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    public class ScubaDiver : Diver
    {
        private const int ScubaDiveOxygenLevel = 540;
        private const double discauntPercentage = 0.3;
        public ScubaDiver(string name) 
            : base(name, ScubaDiveOxygenLevel)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            int oxyLevel = (int)Math.Round(TimeToCatch * discauntPercentage);
            OxygenLevel -= oxyLevel;
        }

        public override void RenewOxy()
        {
            OxygenLevel = ScubaDiveOxygenLevel;
        }
    }
}
