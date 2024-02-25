

namespace PlayersAndMonsters
{
   public abstract class Hero
    {
		private string username;
		private int level;

        protected Hero(string username, int level)
        {
            Username = username;
            Level = level;
        }

        public string Username
		{
			get { return username; }
			set { username = value; }
		}
		public int Level
		{
			get { return level; }
			set { level = value; }
		}

        public override string ToString()
        {
            return $"Type: {GetType().Name} Username: {Username} Level: {Level}";
        }
    }
}
