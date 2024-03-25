using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodShortage.Models.Interfaces;

namespace FoodShortage.Models
{
    public class Citizen : BaseHuman, IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
            :base (name, age)
        {
            Id = id;
            Birthdate = birthdate;
        }

        public string Id { get;}
        public string Birthdate { get; }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
