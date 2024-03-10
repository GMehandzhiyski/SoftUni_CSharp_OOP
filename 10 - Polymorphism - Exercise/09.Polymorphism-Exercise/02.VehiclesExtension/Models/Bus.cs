using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double airConditioner = 1.4;

        public Bus(double fuelQuantity, double consumption, double tankCapacity) 
            : base(fuelQuantity, consumption, airConditioner, tankCapacity)
        {
        }

      
    }
}
