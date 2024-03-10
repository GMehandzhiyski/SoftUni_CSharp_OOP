using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double AirConditioner = 0.9;

        public Car(double fuelQuantity, double consumption, double tankCapacity) 
            : base(fuelQuantity, consumption, AirConditioner, tankCapacity)
        {
        }
    }
}
