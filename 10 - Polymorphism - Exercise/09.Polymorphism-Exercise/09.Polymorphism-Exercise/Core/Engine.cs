using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Core.Interfaces;
using Vehicles.Factories;
using Vehicles.Factories.Interfaces;
using Vehicles.IO.Interfaces;
using Vehicles.Models;
using Vehicles.Models.Interfaces;
using System.Globalization;

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
/*
Car 15 0.3
Truck 100 0.9
4
Drive Car 9
Drive Car 30
Refuel Car 50
Drive Truck 10
*/



            // business Logic

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
            double thrid =  double.Parse(vehicleInput[3]);

           IVehicle vehicle = vehicleFactory.Create(vehicleInput[0], double.Parse(vehicleInput[1]), double.Parse(vehicleInput[2]));
        
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
        }
    }



}
