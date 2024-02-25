

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double CoffeeMilliliters = 50;
        private const decimal CoffePrice = 3.50M;

        private double caffeine;

        public Coffee(string name, double caffeine)
            : base(name, CoffePrice, CoffeeMilliliters)
        {
            Caffeine = caffeine;
        }
        public double Caffeine
        {
            get { return caffeine; }
            set { caffeine = value; }
        }
        



    }
}
