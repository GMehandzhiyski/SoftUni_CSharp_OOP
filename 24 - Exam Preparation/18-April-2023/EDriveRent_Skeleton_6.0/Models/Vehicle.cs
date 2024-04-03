using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;

namespace EDriveRent.Models
{

    public abstract class Vehicle : IVehicle
    {

        private string brand;
        private string model;
        private double maxMileage;
        private string licensePlateNumber;
        private int batteryLevel;
        private bool isDamaged;


        protected Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
        {
            Brand = brand;
            Model = model;
            this.maxMileage = maxMileage;
            LicensePlateNumber = licensePlateNumber;
            batteryLevel = 100;
            this.isDamaged = false;
        }

        public string Brand
        {
            get => brand;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.BrandNull));
                }
                brand = value;
            }
        }

        public string Model
        {
            get => model; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.ModelNull));
                }
                model = value;
            }
        }

        public double MaxMileage => maxMileage;

        public string LicensePlateNumber
        {
            get { return licensePlateNumber; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.LastNameNull));
                }
                licensePlateNumber = value;
            }
        }

        public int BatteryLevel => batteryLevel;

        public bool IsDamaged => isDamaged;

        public void Drive(double mileage)
        {
            double percentage = Math.Round((mileage / MaxMileage) * 100);
            batteryLevel -= (int)percentage;

            if (GetType().Name == nameof(CargoVan))
            {
                batteryLevel -= 5;
            }

        }
        public void Recharge()
        {
             batteryLevel = 100;
        }

        public void ChangeStatus()
        {
            if (!IsDamaged)
            {
                isDamaged = true;
            }
            else
            { 
                isDamaged = false;
            }
        }

        public override string ToString()
        {
           string condition = string.Empty;
            if (IsDamaged)
            {
                condition = "damaged";
            }
            else
            {
                condition = "OK";
            }
            return $"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: {condition}";
        }

    }
}
