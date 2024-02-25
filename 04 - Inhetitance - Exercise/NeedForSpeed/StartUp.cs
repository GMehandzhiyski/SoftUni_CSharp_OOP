using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
          FamilyCar moto = new(150, 100.0);
            moto.Drive(10);
            Console.WriteLine(moto.Fuel);

        }
    }
}
