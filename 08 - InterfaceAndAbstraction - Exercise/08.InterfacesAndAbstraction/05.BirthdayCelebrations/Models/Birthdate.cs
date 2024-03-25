

namespace BirthdayCelebrations.Models
{
    public class Birthdate
    {
		private List<BirthdateEntity> birthdates;

        public Birthdate()
        {
            birthdates = new List<BirthdateEntity>();
         }
        public List<BirthdateEntity> Birthdates
        {
			get { return birthdates; }
			set { birthdates = value; }
		}

        public void AddNumber(BirthdateEntity entyti)
        {
            birthdates.Add(entyti);
        }

      
	}
}
