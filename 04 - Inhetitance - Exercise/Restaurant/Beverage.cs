

namespace Restaurant
{
    public abstract class Beverage : Product
    {
        private double milliliters;

        public Beverage(string name, decimal price, double milliliters) 
            : base(name, price)
        {
            Milliliters = milliliters;  
        }

        public double Milliliters
        {
            get { return milliliters; }
            set { milliliters = value; }
        }
    }
}
