using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Repositories.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Core
{
    public class Controller : IController
    {

        IRepository<ISupplement> supplements;
        IRepository<IRobot> robots;
        public Controller()
        {
            supplements = new SupplementRepository();
            robots = new RobotRepository(); 
        }

        public string CreateRobot(string model, string typeName)
        {
            if (typeName == nameof(DomesticAssistant))
            {
                robots.AddNew(new DomesticAssistant(model));
            }
            else if (typeName == nameof(IndustrialAssistant))
            {
                robots.AddNew(new IndustrialAssistant(model));
            }
            else
            {
               return string.Format(OutputMessages.RobotCannotBeCreated,typeName);
            }

            return string.Format(OutputMessages.RobotCreatedSuccessfully,typeName, model);
        }

        public string CreateSupplement(string typeName)
        {
            if (typeName == nameof(SpecializedArm))
            {
                supplements.AddNew(new SpecializedArm());
            }
            else if (typeName == nameof(LaserRadar))
            {
                supplements.AddNew(new LaserRadar());
            }
            else
            {
                string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }

            return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplement = supplements
                .Models()
                .FirstOrDefault(c => c.GetType().Name == supplementTypeName);

            IRobot robot = robots
                .Models()
                .FirstOrDefault(c => c.Model == model && c.InterfaceStandards.Contains(supplement.InterfaceStandard));

            if (robot == null)
            {
                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }

            robot.InstallSupplement(supplement);
            supplements.RemoveByName(supplementTypeName);

            return string.Format(OutputMessages.UpgradeSuccessful,model, supplementTypeName);
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            IEnumerable<IRobot> filteredRobots = robots
                .Models()
                .Where(r => r.InterfaceStandards.Contains(intefaceStandard))
                .OrderByDescending(r => r.BatteryLevel);

            if (!filteredRobots.Any())
            {
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }

            int sumBatteryLevel = filteredRobots.Sum(r => r.BatteryLevel);

            if (sumBatteryLevel < totalPowerNeeded)
            {
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - sumBatteryLevel);
            }

            int robotsCounter = 0;

            foreach (IRobot robot in filteredRobots)
            {
                robotsCounter++;
                if (robot.BatteryLevel >= totalPowerNeeded)
                {
                    robot.ExecuteService(totalPowerNeeded);
                    break;
                }
                
                totalPowerNeeded -= robot.BatteryLevel;
                robot.ExecuteService(totalPowerNeeded);
                
            }

            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, robotsCounter);

        }
        public string RobotRecovery(string model, int minutes)
        {
            
            IEnumerable<IRobot> currRobots = robots
                 .Models()
                //.Where(r => r.BatteryLevel < (r.BatteryCapacity/2));
             .Where(r => r.Model == model && r.BatteryLevel < (r.BatteryCapacity/2));    ////TO Chek  
 
            int fedCount = 0;

            foreach (IRobot robot in currRobots) 
            {
                robot.Eating(minutes);
                fedCount++;
            }

            return string.Format(OutputMessages.RobotsFed, fedCount);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            IEnumerable<IRobot> filtredRobots = robots
                .Models()
                .OrderByDescending(r => r.BatteryLevel)
                .OrderBy(r => r.BatteryCapacity);
              //.ThenBy(r => r.BatteryCapacity);  /////// to check



            foreach (IRobot robot in filtredRobots)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().Trim();
        }

       
    }
}
