using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using RobotService.Models.Contracts;

namespace RobotService.Models
{
    public abstract class Robot : IRobot
    {
        //private string model;
        //private int batteryCapacity;
        //private int batteryLevel;
        //private int convertionCapacityIndex;

        //protected Robot(string model, int batteryCapacity, int convertionCapacityIndex)
        //{
        //    Model = model;
        //    BatteryCapacity = batteryCapacity;
        //    ConvertionCapacityIndex = convertionCapacityIndex; 


        //}
        //public string Model
        //{
        //    get { return model; }

        //    set
        //    {
        //        if (string.IsNullOrWhiteSpace(value))
        //        {
        //            throw new ArgumentException("Model cannot be null or empty.");
        //        }

        //        model = value;
        //    }

        //}

        //public int BatteryCapacity
        //{

        //    get { return batteryCapacity; }

        //    set
        //    {
        //        if (value < 0)
        //        {
        //            throw new ArgumentException("Battery capacity cannot drop below zero.");
        //        }

        //        batteryCapacity = value;
        //    }
        //}


        //////////////// TO DO
        //public int BatteryLevel
        //{
        //    get { return batteryLevel; }

        //    set
        //    {

        //        batteryCapacity = value;
        //    }

        //}

        //public int ConvertionCapacityIndex {get; private set;}

        //public IReadOnlyCollection<int> InterfaceStandards => throw new NotImplementedException();

        //public void Eating(int minutes)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool ExecuteService(int consumedEnergy)
        //{
        //    throw new NotImplementedException();
        //}

        //public void InstallSupplement(ISupplement supplement)
        //{
        //    throw new NotImplementedException();
        //}
        public string Model => throw new NotImplementedException();

        public int BatteryCapacity => throw new NotImplementedException();

        public int BatteryLevel => throw new NotImplementedException();

        public int ConvertionCapacityIndex => throw new NotImplementedException();

        public IReadOnlyCollection<int> InterfaceStandards => throw new NotImplementedException();

        public void Eating(int minutes)
        {
            throw new NotImplementedException();
        }

        public bool ExecuteService(int consumedEnergy)
        {
            throw new NotImplementedException();
        }

        public void InstallSupplement(ISupplement supplement)
        {
            throw new NotImplementedException();
        }
    }
}
