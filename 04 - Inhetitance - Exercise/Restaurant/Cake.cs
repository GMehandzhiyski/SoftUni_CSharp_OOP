
namespace Restaurant
{
    public class Cake : Dessert
    {
        private const decimal PriceC = 5M;
        private const double GramsC = 250;
        private const double Calories = 1000;

        public Cake(string name) 
            : base(name, PriceC, GramsC, Calories)
        {
        }
    }
}
