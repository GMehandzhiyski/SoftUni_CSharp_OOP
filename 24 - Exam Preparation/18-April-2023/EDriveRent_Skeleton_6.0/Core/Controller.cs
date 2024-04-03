using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Utilities.Messages;

namespace EDriveRent.Core
{
    public class Controller : IController
    {
        private UserRepository userRepository;
        private VehicleRepository vehicleRepository;
        private RouteRepository routeRepository;

        public Controller()
        {
            userRepository = new UserRepository();
            vehicleRepository = new VehicleRepository();
            routeRepository = new RouteRepository();
        }
        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            string result = string.Empty;



            if (userRepository.FindById(drivingLicenseNumber) != default)
            {
                result = string.Format(OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber);
            }
            else
            {

                IUser currUser = new User(firstName, lastName, drivingLicenseNumber);
                userRepository.AddModel(currUser);
                result = string.Format(OutputMessages.UserSuccessfullyAdded, firstName, lastName, drivingLicenseNumber);
            }

            return result;
        }
        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            string result = string.Empty;
            if (vehicleType != nameof(PassengerCar)
                && vehicleType != nameof(CargoVan))
            {
                result = string.Format(OutputMessages.VehicleTypeNotAccessible, vehicleType);
            }

            else if (vehicleRepository.FindById(licensePlateNumber) != default)
            {
                result = string.Format(OutputMessages.LicensePlateExists, licensePlateNumber);
            }

            else
            {


                if (vehicleType == nameof(PassengerCar))
                {
                    IVehicle currVehicle = new PassengerCar(brand, model, licensePlateNumber);
                    vehicleRepository.AddModel(currVehicle);
                }
                else
                {
                    IVehicle currVehicle = new CargoVan(brand, model, licensePlateNumber);
                    vehicleRepository.AddModel(currVehicle);
                }

                result = string.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
            }


            return result;
        }

        public string AllowRoute(string startPoint, string endPoint, double length)
        {
            string result = string.Empty;

            int roudeId = routeRepository.GetAll().Count + 1;

            IRoute sameRoute = routeRepository
                .GetAll()
                .FirstOrDefault(s => s.StartPoint == startPoint
                       && s.EndPoint == endPoint);

            if (sameRoute != default)
            {
                if (sameRoute.Length == length)
                {
                    result = string.Format(OutputMessages.RouteExisting, startPoint, endPoint, length);
                }

                else if (sameRoute.Length < length)
                {
                    result = string.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint);
                }
                else if (sameRoute.Length > length)
                { 
                    sameRoute.LockRoute();
                    IRoute newRoute = new Route(startPoint, endPoint, length, roudeId);
                    routeRepository.AddModel(newRoute);
                    result = string.Format(OutputMessages.NewRouteAdded, startPoint, endPoint, length);
                }
            }
            else
            {
                IRoute newRoute = new Route(startPoint, endPoint, length, roudeId);
                routeRepository.AddModel(newRoute);
                result = string.Format(OutputMessages.NewRouteAdded, startPoint, endPoint, length);

            }

            return result;
        }

        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
           string result = string.Empty;

            var currUser = userRepository.FindById(drivingLicenseNumber);
            var currVehicle = vehicleRepository.FindById(licensePlateNumber);
            var currRoute = routeRepository.FindById(routeId);

            if (currUser.IsBlocked)
            {
                result = string.Format(OutputMessages.UserBlocked, drivingLicenseNumber);
            }

            else if (currVehicle.IsDamaged)
            {
                result = string.Format(OutputMessages.VehicleDamaged, licensePlateNumber);
            }

            else if (currRoute.IsLocked)
            {
                result = string.Format(OutputMessages.RouteLocked, routeId);
            }
            else 
            {
                currVehicle.Drive(currRoute.Length);
                // currVehicle.BatteryLevel(currRoute.Length);

                if (isAccidentHappened)
                {
                    currVehicle.ChangeStatus();
                    currUser.DecreaseRating();

                }
                else
                { 
                 currUser.IncreaseRating();
                }

                result = currVehicle.ToString().Trim();
            }
            return result;
        }


        public string RepairVehicles(int count)
        {
            var damageVehicle = vehicleRepository
                .GetAll()
                .Where(v => v.IsDamaged == true)
                .OrderBy(v => v.Brand)
                .ThenBy(v => v.Model);

            int vehiclesCount = 0;

            if (damageVehicle.Count() < count)
            {
                vehiclesCount = damageVehicle.Count();
            }
            else
            {
                vehiclesCount = count;
            }

            var  selectedVehicles = damageVehicle.ToArray().Take(vehiclesCount);

            foreach (var vehicle in selectedVehicles)
            {
                vehicle.ChangeStatus();
                vehicle.Recharge();    
            }

            return string.Format(OutputMessages.RepairedVehicles, vehiclesCount);
        }


        public string UsersReport()
        {
            StringBuilder  sb = new StringBuilder();

            var selectedUser = userRepository
                .GetAll()
                .OrderByDescending(r => r.Rating)
                .ThenBy(l => l.LastName)
                .ThenBy(f => f.FirstName);

            sb.AppendLine("*** E-Drive-Rent ***");
            foreach ( var user in selectedUser)
            {
                sb.AppendLine(user.ToString().Trim());
            }

            return sb.ToString().Trim();   
        }
    }
}
