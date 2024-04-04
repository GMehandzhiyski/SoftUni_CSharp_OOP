using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    public class FreeDiver : Diver
    {
        private const int freeDiverOxygenLevel = 120;
        private const double discauntPrecente = 0.6;
        public FreeDiver(string name)
            : base(name, freeDiverOxygenLevel)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            // double намаление = (число * намалениеПроцент) / 100;ю
           int oxyLevel = (int)Math.Round(TimeToCatch * discauntPrecente);
            OxygenLevel -= oxyLevel;
        }
        public override void RenewOxy()
        {
           OxygenLevel = freeDiverOxygenLevel;
        }
    }
}
