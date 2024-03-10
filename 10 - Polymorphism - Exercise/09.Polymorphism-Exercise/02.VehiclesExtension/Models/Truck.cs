using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double AirConditionar = 1.6;

        public Truck(double fuelQuantity, double consumption, double tankCapacity) 
            : base(fuelQuantity, consumption, AirConditionar, tankCapacity)
        {
        }

        public override void Refueling(double amount)
            =>base.Refueling(amount) ;
        
    }
}
