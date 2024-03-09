using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double AirConditioner;

        protected Vehicle(double fuelQuantity, double consumption, double airConditioner)
        {
            AirConditioner = airConditioner;
            FuelQuantity = fuelQuantity;
            FuelConsumption = consumption;
        }

        public double FuelQuantity { get; private set; }

        public double FuelConsumption { get; private set; }

        public  string Driving(double distance)
        {
            double consumption = FuelConsumption + AirConditioner;
            if (FuelQuantity <= distance * consumption)
            {
                throw new ArgumentException($"{GetType().Name} needs refueling");
            }
            
            FuelQuantity -= distance * consumption;
            return $"{GetType().Name} travelled {distance} km";
        }

        public virtual void Refueling(double amount)
        {
           FuelQuantity += amount;
        }

        public override string ToString()
        { 
           return $"{GetType().Name}: {FuelQuantity:f2}";
        }
  
        
    }
}
