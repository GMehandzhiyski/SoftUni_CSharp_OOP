using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models
{
    public abstract class Robot : IRobot
    {
        private string model;
        private int batteryCapacity;

        private readonly List<int> interfaceStandards;


        protected Robot(string model, int batteryCapacity, int convertionCapacityIndex)
        {
            Model = model;
            BatteryCapacity = batteryCapacity;
            BatteryLevel = batteryCapacity;
            ConvertionCapacityIndex = convertionCapacityIndex;

            interfaceStandards = new List<int>();

        }
        public string Model
        {
            get => model;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNullOrWhitespace);
                }

                model = value;
            }

        }

        public int BatteryCapacity
        {

            get => batteryCapacity;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.BatteryCapacityBelowZero);
                }

                batteryCapacity = value;
            }
        }



        public int BatteryLevel { get; private set; }


        public int ConvertionCapacityIndex { get; private set; }

        public IReadOnlyCollection<int> InterfaceStandards => interfaceStandards.AsReadOnly();

        public void Eating(int minutes)
        {
            int totalCapacity = ConvertionCapacityIndex * minutes;

            if (totalCapacity > BatteryCapacity - BatteryLevel)
            {
                BatteryLevel = BatteryCapacity;
            }
            else
            {
                BatteryLevel += totalCapacity;
            }


        }
        public void InstallSupplement(ISupplement supplement)
        {
            interfaceStandards.Add(supplement.InterfaceStandard);

            BatteryCapacity -= supplement.BatteryUsage;
            BatteryLevel -= supplement.BatteryUsage;
        }

        public bool ExecuteService(int consumedEnergy)
        {
            //BatteryLevel -= consumedEnergy;
            if (BatteryLevel >= consumedEnergy)
            {
                BatteryLevel -= consumedEnergy;
                return true;
            }

            return false;

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name} {Model}:");
            sb.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
            sb.AppendLine($"--Current battery level: {BatteryLevel}");
            sb.AppendLine("--Supplements installed:");


            string supplementsInstalled = InterfaceStandards.Any()
                ? $"{string.Join(" ", InterfaceStandards)}"
                : "none";
            //if (InterfaceStandards.Any())
            //{
            //    foreach (var item in interfaceStandards) ///// To check 
            //    {
            //        sb.Append($"{item} ");
            //    }
            //}
            //else
            //{
            //    sb.Append("none");
            //}


            return sb.ToString().Trim();
        }
    }
}
