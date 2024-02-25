
namespace Zoo
{
   public abstract class Animal
    {
		private string name;

        protected Animal(string name)
        {
            Name = name;
        }

        public string Name
		{
			get { return name; }
			set { name = value; }
		}


	}
}
