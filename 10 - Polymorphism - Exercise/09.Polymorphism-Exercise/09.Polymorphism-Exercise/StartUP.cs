using Vehicles.Core;
using Vehicles.Core.Interfaces;
using Vehicles.IO;
using Vehicles.IO.Interfaces;

namespace Vehicles
{
    internal class StartUP
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(reader, writer);
            //IVehicleFactory = vehicleFactory = new VehicleFactory()

            engine.Run();
        }
    }
}
