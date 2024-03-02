

using System.Runtime.CompilerServices;
using System.Transactions;

namespace PizzaCalories.Model
{
    public class Topping
    {
        private Dictionary<string, double> toppingCalories ;


		private string toppintType;
		private double weight ;
		private double calories;


		public Topping(string toppintType, double weight)
		{
			toppingCalories =
				new Dictionary<string, double>{{ "meat", 1.2 },
											   { "veggies",0.8},
											   {"cheese", 1.1},
											   {"sauce", 0.9 } };
			ToppintType = toppintType;
			Weight = weight;
		 }
        public string ToppintType
        {
			get { return toppintType; }
			private set 
			{
                if (!toppingCalories.Keys.Contains(value.ToLower()))
                {
					throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                toppintType = value.ToLower();
			}
		}

		public double Weight 
		{
			get { return weight; }
			private set
			{
                if (value < 1
					|| value > 50)
                {
					throw new ArgumentException($"{toppintType} weight should be in the range [1..50].");
                }
                weight = value;
			}
		}

		public double Calories
		{
			get 
			{ double cuurCaloriesTopping = toppingCalories[ToppintType];

                return 2*(Weight*cuurCaloriesTopping); 
			}
			
		}



	}
}
