using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            BladeKnight bladeKnight = new BladeKnight("Pesho", 25);
            Console.WriteLine(bladeKnight.ToString());

        }
    }
}