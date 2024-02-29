
namespace ShoppingSpree.Model
{
    public class Product
    {
		private string name;
		private decimal cost;

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name
		{
			get { return name; }
			set
			{
                if (string.IsNullOrWhiteSpace(value)
                    || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");	
                }
                name = value;
			}
		}
		public decimal Cost
		{
			get { return cost; }
			set
			{
                if (value <= 0 )
                {
                    throw new ArgumentException("Price cannot be zero or negative");
                }
                cost = value;
			}
		}


	}
}
