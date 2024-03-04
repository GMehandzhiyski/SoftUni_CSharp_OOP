using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodShortage.Models.Interfaces;

namespace FoodShortage.Models
{
    public  abstract class BaseHuman: IBuyer
    {
        protected BaseHuman(string name, int age)
        {
            Name = name;
            Age = age;
            Food = 0;
        }

        public string  Name { get; }
        public int Age { get; }
        public int Food { get; protected set ; }

        public void BuyFood()
        {
           
        }
    }
}
