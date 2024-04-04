using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Repositories.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NauticalCatchChallenge.Core
{
    public class Controller : IController
    {
        private IRepository<IDiver> diversRepository;
        private IRepository<IFish> fishesRepository;

        public Controller()
        {
            diversRepository = new DiverRepository();
            fishesRepository = new FishRepository();    
        }
        public string DiveIntoCompetition(string diverType, string diverName)
        {
            if (diverType != nameof(FreeDiver)
                && diverType != nameof(ScubaDiver))
            {
                return string.Format(OutputMessages.DiverTypeNotPresented,diverType);
            }

            if (diversRepository.GetModel(diverName) != default)
            {
                return string.Format(OutputMessages.DiverNameDuplication, diverName,nameof(DiverRepository));
            }

            IDiver newDiver = default;
            if (diverType == nameof(FreeDiver))
            {
                newDiver = new FreeDiver(diverName);
             

            }
            else if(diverType == nameof(ScubaDiver))
            {
                newDiver = new ScubaDiver(diverName);
                
            }

            diversRepository.AddModel(newDiver);
            return string.Format(OutputMessages.DiverRegistered, diverName, nameof(DiverRepository));
        }

        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            if (fishType != nameof(ReefFish)
                && fishType != nameof(DeepSeaFish)
                && fishType != nameof(PredatoryFish))
            {
                return string.Format(OutputMessages.FishTypeNotPresented, fishType);
            }

            if (fishesRepository.GetModel(fishName) != default)
            {
                return string.Format(OutputMessages.FishNameDuplication,fishName,nameof(FishRepository));
            }

            IFish newFish = default;
            if (fishType == nameof(ReefFish))
            {
                newFish = new ReefFish(fishName,points);
            }
            else if (fishType == nameof(DeepSeaFish))
            {
                newFish = new DeepSeaFish(fishName, points);
            }
            else if (fishType == nameof(PredatoryFish))
            { 
                newFish = new PredatoryFish(fishName,points);   
            }

            fishesRepository.AddModel(newFish);
            return string.Format(OutputMessages.FishCreated, fishName);
        }


        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            IDiver currDiver = diversRepository.GetModel(diverName);
            IFish currFish = fishesRepository.GetModel(fishName);

            if (currDiver == default)
            {
                return string.Format(OutputMessages.DiverNotFound,nameof(DiverRepository), diverName);
            }

            if (currFish == default)
            {
                return string.Format(OutputMessages.FishNotAllowed,fishName);
            }

            if (currDiver.HasHealthIssues)
            {
                return string.Format(OutputMessages.DiverHealthCheck,diverName);
            }

            if (currDiver.OxygenLevel <  currFish.TimeToCatch)
            {
                currDiver.Miss(currFish.TimeToCatch);
                if (currDiver.OxygenLevel <= 0)
                {
                    currDiver.UpdateHealthStatus();
                }
                return string.Format(OutputMessages.DiverMisses,diverName, fishName);
            }

            if (currDiver.OxygenLevel == currFish.TimeToCatch)
            {
                if (isLucky)
                {
                    currDiver.Hit(currFish);
                    if (currDiver.OxygenLevel <= 0)
                    {
                        currDiver.UpdateHealthStatus();
                    }
                    return string.Format(OutputMessages.DiverHitsFish, diverName, currFish.Points, fishName);
                }
                else
                {
                    currDiver.Miss(currFish.TimeToCatch);
                    if (currDiver.OxygenLevel <= 0)
                    {
                        currDiver.UpdateHealthStatus();
                    }
                    return string.Format(OutputMessages.DiverMisses, diverName, fishName);

                }
            }

            if (currDiver.OxygenLevel > currFish.TimeToCatch)
            {
                currDiver.Hit(currFish);
                if (currDiver.OxygenLevel <= 0)
                {
                    currDiver.UpdateHealthStatus();
                }
                return string.Format(OutputMessages.DiverHitsFish, diverName, currFish.Points, fishName);
            }

            return default;
        }
        public string HealthRecovery()
        {
            var diversWithHaeltyIssue = diversRepository.Models.Where(d => d.HasHealthIssues == true);
            int count = 0;
            foreach (var currDiver in diversWithHaeltyIssue)
            {
                currDiver.UpdateHealthStatus();
                currDiver.RenewOxy();
                count++;
            }

            return string.Format(OutputMessages.DiversRecovered, count);
        }

        public string DiverCatchReport(string diverName)
        {
           var currDiver = diversRepository.GetModel(diverName);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Diver [ Name: {currDiver.Name}, Oxygen left: {currDiver.OxygenLevel}, Fish caught: {currDiver.Catch.Count()}, Points earned: {currDiver.CompetitionPoints} ]");
            sb.AppendLine($"Catch Report:");

            foreach (var fishName in currDiver.Catch)
            {
                IFish currFish = fishesRepository.GetModel(fishName);
                sb.AppendLine(currFish.ToString());
            }

            return sb.ToString().Trim();
        }

        public string CompetitionStatistics()
        {
            var filtredDiver = diversRepository
                    .Models
                    .Where(d => d.HasHealthIssues == false)
                    .OrderByDescending(d => d.CompetitionPoints)
                    .ThenBy(d => d.Catch.Count)
                    .ThenBy(d => d.Name);
            
            StringBuilder  sb = new StringBuilder();

            sb.AppendLine("**Nautical-Catch-Challenge**");

            foreach (var diver in filtredDiver)
            {
                sb .AppendLine(diver.ToString());
            }

            return sb.ToString().Trim();
        }




    }
}
