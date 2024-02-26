

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
		private decimal salary;
  
        public Person(string name,string lastName, int age, decimal salary)
        {
            FirstName = name;
			LastName = lastName;
            Age = age;
            Salary = salary;
        }

        public string FirstName
        {
			get { return firstName; }
			private set { firstName = value; }
		}

        public string  LastName
        {
            get { return lastName; }
            private set {lastName = value; }
        }
        public int Age
		{
			get { return age; }
			private set { age = value; }
		}
		public decimal Salary
		{
			get { return salary; }
			private set { salary = value; }
        }


        public void IncreaseSalary(decimal percentage)
		{ 
            if (Age > 30)
            {
             Salary += (Salary * percentage)/100;
            }
            else 
            {
                Salary += ((Salary * percentage) / 100)/2;
            }
		
		}

        public override string ToString()
            => $"{FirstName} {LastName} receives {Salary:f2} leva.";

    }
}
