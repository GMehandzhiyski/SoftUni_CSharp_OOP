using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class DomesticAssistant : Robot
    {
        private const int DomesticAssistantBatteryCapacity = 20_000;
        private const int DomesticAssistanceConvertionCapacityIndex = 2_000;

        public DomesticAssistant(string model)
            : base(model, DomesticAssistantBatteryCapacity, DomesticAssistanceConvertionCapacityIndex)
        {
        }
    }
}
