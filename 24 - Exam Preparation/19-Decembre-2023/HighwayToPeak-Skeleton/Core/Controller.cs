using HighwayToPeak.Core.Contracts;
using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories;
using HighwayToPeak.Repositories.Contracts;
using HighwayToPeak.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HighwayToPeak.Core
{
    public class Controller : IController
    {
        private IRepository<IClimber> climberRepository;
        private IRepository<IPeak> peakRepository;
        private BaseCamp baseCamp;

        public Controller()
        {
            climberRepository = new ClimberRepository();
            peakRepository = new PeakRepository();
            baseCamp = new BaseCamp();
        }


        public string AddPeak(string name, int elevation, string difficultyLevel)
        {
            //IPeak currPeak = peakRepository.Get(name);
            if (peakRepository.Get(name) != default)
            {
                return string.Format(OutputMessages.PeakAlreadyAdded,name);
            }

            if (difficultyLevel != "Extreme"
                && difficultyLevel != "Hard"
                && difficultyLevel != "Moderate")
            {
                return string.Format(OutputMessages.PeakDiffucultyLevelInvalid,difficultyLevel);
            }
          
            IPeak newPeak = new Peak(name, elevation, difficultyLevel);
            peakRepository.Add(newPeak);


            return string.Format(OutputMessages.PeakIsAllowed,name,nameof(PeakRepository));
        }

        public string NewClimberAtCamp(string name, bool isOxygenUsed)
        {
            if (climberRepository.Get(name) != default)
            {
                return string.Format(OutputMessages.ClimberCannotBeDuplicated, name, nameof(ClimberRepository));
            }

            IClimber newClimber = default;
           // BaseCamp newBaseCapmClimber;

            if (isOxygenUsed)
            {
                newClimber = new OxygenClimber(name);
            }
            else
            {
                newClimber = new NaturalClimber(name);
            }

            climberRepository.Add(newClimber);
            baseCamp.ArriveAtCamp(name);

            return string.Format(OutputMessages.ClimberArrivedAtBaseCamp, name);
        }

        public string AttackPeak(string climberName, string peakName)
        {

            if (climberRepository.Get(climberName) == default)
            {
                return string.Format(OutputMessages.ClimberNotArrivedYet,climberName);
            }

            if (peakRepository.Get(peakName) == default)
            {
                return string.Format(OutputMessages.PeakIsNotAllowed, peakName);
            }

            if (!baseCamp.Residents.Contains(climberName))
            {
                return string.Format(OutputMessages.ClimberNotFoundForInstructions,climberName, peakName);
            }

            IClimber currClimber = climberRepository.Get(climberName);
            IPeak currPeak = peakRepository.Get(peakName);

            if (currPeak.DifficultyLevel == "Extreme"
                && currClimber.GetType().Name == nameof(NaturalClimber))
            {
                return string.Format(OutputMessages.NotCorrespondingDifficultyLevel,climberName,peakName);
            }

            baseCamp.LeaveCamp(climberName);
            currClimber.Climb(currPeak);

            if (currClimber.Stamina == 0)
            {
                return string.Format(OutputMessages.NotSuccessfullAttack, climberName);
            }
         
             baseCamp.ArriveAtCamp(climberName);
             return string.Format(OutputMessages.SuccessfulAttack,climberName,peakName); 
        }

        public string CampRecovery(string climberName, int daysToRecover)
        {
            if (baseCamp.Residents.Contains(climberName) == default )
            {
                return string.Format(OutputMessages.ClimberIsNotAtBaseCamp, climberName);
            }

            IClimber currClimber = climberRepository.Get(climberName);
            if (currClimber.Stamina == 10)
            {
                return string.Format(OutputMessages.NoNeedOfRecovery, climberName);
            }
            else
            {
                

                currClimber.Rest(daysToRecover);
                return string.Format(OutputMessages.ClimberRecovered, climberName, daysToRecover);
            }
            return default;
        }

        public string BaseCampReport()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("BaseCamp residents:");

             if (baseCamp.Residents.Count == 0)
            {
                sb.AppendLine("BaseCamp is currently empty.");
            }
            else 
            {
                foreach (var baseClimber in baseCamp.Residents)
                {
                    IClimber currClimber = climberRepository.Get(baseClimber);

                    sb.AppendLine($"Name: {currClimber.Name}, Stamina: {currClimber.Stamina}, Count of Conquered Peaks: {currClimber.ConqueredPeaks.Count}");
                }
            }
           

            return sb.ToString().Trim();
        }



        public string OverallStatistics()
        {
            StringBuilder sb = new StringBuilder();

            var sortedClimners = climberRepository
               .All
               .OrderByDescending(c => c.ConqueredPeaks.Count)
               .ThenBy(n => n.Name);

            sb.AppendLine("***Highway-To-Peak***");

            foreach (var climber in sortedClimners)
            {
                sb.AppendLine(climber.ToString());
                var filtredPeak = new List<IPeak>();

                foreach (var peak in climber.ConqueredPeaks)
                {
                   IPeak peakPeak = peakRepository.Get(peak);
                    filtredPeak.Add(peakPeak);
                }

                foreach (var peak in filtredPeak.OrderByDescending(f => f.Elevation))
                {
                    
                    sb.AppendLine(peak.ToString());
                }
               
            }


            return sb.ToString().Trim();    
        }
    }
}
