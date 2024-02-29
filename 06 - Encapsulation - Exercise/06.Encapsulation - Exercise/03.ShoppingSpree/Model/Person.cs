

using System.Diagnostics.Metrics;

namespace ShoppingSpree.Model
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            Bag = new List<Product>();
        }

        public string Name
        {
            get { return name; }
            private set
            {

                if (string.IsNullOrWhiteSpace(value)
                || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be empty");
                }
                name = value;
            }
        }
        public decimal Money
        {
            get { return money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }
        public List<Product> Bag
        {
            get { return bag; }
            set { bag = value; }
        }

        public string AddProductToBag(Product product)
        {
            if (Money < product.Cost)
            {
                return $"{Name} can't afford {product.Name}";
            }
            else
            {
                Money -= product.Cost;
                bag.Add(product);
                return $"{Name} bought {product.Name}";
            }

        }

        public override string ToString()
        {
            if (this.bag.Count == 0)
            {
                return $"{this.Name} - Nothing bought";
            }

            return $"{this.Name} - {String.Join(", ", this.bag.Select(p => p.Name))}";
        }


    }
}
