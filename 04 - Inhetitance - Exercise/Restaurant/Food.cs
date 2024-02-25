

namespace Restaurant
{
    public abstract class Food : Product
    {
        private double grams;

       public Food(string name, decimal price, double grams) 
            : base(name, price)
        {
            Grams = grams;
        }
        public double Grams
        {
            get { return grams; }
            set { grams = value; }
        }
    }
}
