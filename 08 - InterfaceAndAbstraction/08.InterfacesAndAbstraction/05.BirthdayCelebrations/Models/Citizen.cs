

using BirthdayCelebrations.Models.Interfaces;


namespace BirthdayCelebrations.Models
{
    public class Citizen : BirthdateEntity
    {
        public Citizen(string name, int age, string id,string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; set; }

    }
}
