
using PizzaCalories.Model;

namespace PizzaCalories.Model
{
    public class Pizza
    {
		private string name;
		private Dough dough;
		private List<Topping> toppings;
		private double calories;



		public Pizza(string name, Dough dough)
        {
            Name = name;
            Dough = dough;
            Toppings = new List<Topping>();
        }

        public string Name
		{
			get { return name; }
			private set
			{
				if ((value.Length < 1
					|| value.Length > 15))
				{
					throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
				}
				name = value;
			}
		}
		public Dough Dough

		{
            get { return dough; }
			set { dough = value; }
		}
		public List<Topping> Toppings
		{
			get { return toppings; }
			set { toppings = value; }
        }
		public double Calories
		{
			get
			{
				return Dough.Calories + toppings.Sum(t => t.Calories);
			}
		}

		public void AddToping(Topping newTopping)
		{
            if (toppings.Count > 10)
            {
				throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(newTopping);
		}

        public override string ToString()
        {
            return $"{Name} - {Calories:f2} Calories.";	
        }


    }
}
