using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double airConditioner;
        private double fuelQuantity;
        private double tankCapacity;
        private double fuelConsumption;
  

        public Vehicle(double fuelQuantity, double consumption, double airConditioner, double tankCapacity)
        {
            TankCapacity = tankCapacity;    
            this.airConditioner = airConditioner;
            FuelQuantity = fuelQuantity;
            FuelConsumption = consumption;
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fuel must be positive number");
                }

                if (value <= TankCapacity)
                {
                    fuelQuantity = value;
                }
                else
                {
                    fuelQuantity = 0;
                }
            }
        }   
        public double TankCapacity 
        {
            get { return tankCapacity; }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Tank must be a positive number");
                }
                tankCapacity = value;
            } 
        
        }

        

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Consumption must be a positive number");
                }
                fuelConsumption = value;
            }
        }

        public virtual string Driving(double distance)
        {
            double consumption = FuelConsumption + airConditioner;
            if (FuelQuantity <= distance * consumption)
            {
                throw new ArgumentException($"{GetType().Name} needs refueling");
            }
            
            FuelQuantity -= distance * consumption;
            return $"{GetType().Name} travelled {distance} km";
        }
        public virtual string DrivingWithoutPeople(double distance)
        {
            double consumption = FuelConsumption;
            if (FuelQuantity <= distance * consumption)
            {
                throw new ArgumentException($"{GetType().Name} needs refueling");
            }

            FuelQuantity -= distance * consumption;
            return $"{GetType().Name} travelled {distance} km";
        }

        public virtual void Refueling(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }

            if ((FuelQuantity + amount) > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
            }

            FuelQuantity += amount;
        }

        public override string ToString()
        { 
           return $"{GetType().Name}: {FuelQuantity:f2}";
        }
  
        
    }
}
