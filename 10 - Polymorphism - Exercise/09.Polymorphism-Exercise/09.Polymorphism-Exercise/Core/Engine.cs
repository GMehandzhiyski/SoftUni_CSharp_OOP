using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Core.Interfaces;
using Vehicles.IO.Interfaces;
using Vehicles.Models;
using Vehicles.Models.Interfaces;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly ICollection<IVehicle> vehicles;
        public Engine(IReader  reader, IWriter writer )
        {
           this.reader = reader;
           this.writer = writer;
            vehicles = new List<IVehicle>();
        }
        public void Run()
        {

            // business Logic
            string[] carInput = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            double first = double.Parse(carInput[1]);
            double second = double.Parse(carInput[2]);
            vehicles.Add(new Car(first, second));

            string[] truckInput = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            vehicles.Add(new Truck(double.Parse(truckInput[1]), double.Parse(truckInput[2])));

            int nLine = int.Parse(reader.ReadLine());

            for (int i = 0; i < nLine; i++)
            {
                try
                {
                    ProcessCommand();
                }
                catch (Exception  ex)
                {

                    writer.WriteLine(ex.Message);
                }              
            }

            foreach (var vehicle in vehicles)
            {
                writer.WriteLine(vehicle.ToString());
            }
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
