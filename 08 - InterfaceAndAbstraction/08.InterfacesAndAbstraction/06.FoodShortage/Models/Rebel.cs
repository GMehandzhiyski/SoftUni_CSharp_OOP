using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodShortage.Models.Interfaces;

namespace FoodShortage.Models
{
    public class Rebel : BaseHuman, IBuyer
    {
        public Rebel(string name, int age, string group)
            :base (name, age)
        {
            
            Group = group;
        }

        public string Group { get; protected set; }

        public void BuyFood()
        {
            Food += 5;
        }
    }
    
}
