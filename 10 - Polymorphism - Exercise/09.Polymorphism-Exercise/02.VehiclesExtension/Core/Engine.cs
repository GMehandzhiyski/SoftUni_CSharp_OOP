using System.Globalization;
using Vehicles.Core.Interfaces;
using Vehicles.Factories.Interfaces;
using Vehicles.IO.Interfaces;
using Vehicles.Models;
using Vehicles.Models.Interfaces;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory vehicleFactory;
     
        private readonly ICollection<IVehicle> vehicles;
        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;
            vehicles = new List<IVehicle>();

          
        }
        public void Run()
        {


            // business Logic

/*
Car 30 0.04 70
Truck 100 0.5 300
Bus 40 0.3 150
8
Refuel Car -10
Refuel Truck 0
Refuel Car 10
Refuel Car 300
Drive Bus 10
Refuel Bus 1000
DriveEmpty Bus 100
Refuel Truck 1000
*/
            vehicles.Add(CreateVehicle());
            vehicles.Add(CreateVehicle());
            vehicles.Add(CreateVehicle());

            int nLine = int.Parse(reader.ReadLine());

            for (int i = 0; i < nLine; i++)
            {
                try
                {
                    ProcessCommand();
                }
                catch (Exception ex)
                {

                    writer.WriteLine(ex.Message);
                }
            }

            foreach (var vehicle in vehicles)
            {
                writer.WriteLine(vehicle.ToString());
            }
        }

        private IVehicle CreateVehicle()
        {

            string[] vehicleInput = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            IVehicle vehicle = vehicleFactory.Create(vehicleInput[0], double.Parse(vehicleInput[1]), double.Parse(vehicleInput[2]), double.Parse(vehicleInput[3]));
        
            return vehicle;
        }

        private void ProcessCommand()
        {
            string[] commandInput = reader.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string method = commandInput[0];
            string type = commandInput[1];
            double value = double.Parse(commandInput[2]);

            IVehicle vehicle = vehicles.FirstOrDefault(c => c.GetType().Name == type);

            if (method == "Drive")
            {
                writer.WriteLine(vehicle.Driving(value));
            }

            else if (method == "Refuel")
            {
                vehicle.Refueling(value);
            }

            else if (method == "DriveEmpty")
            {
                writer.WriteLine(vehicle.DrivingWithoutPeople(value));
            }
        }
    }



}
