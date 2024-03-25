using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotService.Core.Contracts;

namespace RobotService.Core
{
    public class Controller : IController
    {
        public string CreateRobot(string model, string typeName)
        {
            throw new NotImplementedException();
        }

        public string CreateSupplement(string typeName)
        {
            throw new NotImplementedException();
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            throw new NotImplementedException();
        }

        public string Report()
        {
            throw new NotImplementedException();
        }

        public string RobotRecovery(string model, int minutes)
        {
            throw new NotImplementedException();
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            throw new NotImplementedException();
        }
    }
}
