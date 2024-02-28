using Encapsulation.Models;

namespace Encapsulation
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            double surfaceArea = 0 ;
            double lateralSurfaceArea = 0;
            double Volume = 0;
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            try
            {

                Box box = new(lenght, width, height);

                surfaceArea = box.SurfaceArea();
                lateralSurfaceArea = box.LateralSurfaceArea();
                Volume = box.Volume();

                Console.WriteLine($"Surface Area - {surfaceArea:f2}");
                Console.WriteLine($"Lateral Surface Area - {lateralSurfaceArea:f2}");
                Console.WriteLine($"Volume - {Volume:f2}");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

    
        }
    }
}
