﻿
namespace Animals
{
    public class Animal
    {
        public string Name { get; protected set; }
        public string FavoriteFood { get; protected set; }

        public Animal(string name, string favoriteFood)
        {
            Name = name;
            FavoriteFood = favoriteFood;
        }
        public virtual string ExplainSelf()
        {
            return $"I am {Name} and my fovourite food is {FavoriteFood}"
;
        }
    }
}
