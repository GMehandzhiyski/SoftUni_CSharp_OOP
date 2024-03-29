﻿using ValidationAttributes.Atribute;

namespace ValidationAttributes.Models
{
    public class Person
    {
        private const int minValue = 12;
        private const int maxValue = 90;
        public Person(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
                
        }

        [MyRequiredAttribute]
        public string Name { get; set; }
        [MyRange(minValue, maxValue)]
        public int Age { get; set; }
    }
}
