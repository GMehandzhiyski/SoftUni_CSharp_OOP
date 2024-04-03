using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IHotel> hotelsRepo;

        public Controller()
        {
            hotelsRepo = new HotelRepository();
        }
        public string AddHotel(string hotelName, int category)
        {

            if (hotelsRepo.Select(hotelName) != null)
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }

           
            IHotel hotel = new Hotel(hotelName,category); 
            hotelsRepo.AddNew(hotel);

            return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);

           
        }
        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            if (hotelsRepo.Select(hotelName) == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            IHotel hotel = hotelsRepo.Select(hotelName);
            if (hotel.RoomsRepo.Select(roomTypeName) != default)
            {
                return string.Format(OutputMessages.RoomTypeAlreadyCreated);
            }

            IRoom room;
            if (roomTypeName == nameof(Apartment))
            {
                room = new Apartment();
            }
            else if (roomTypeName == nameof(DoubleBed))
            {
                room = new DoubleBed();
            }
            else if (roomTypeName == nameof(Studio))
            {
                room =  new Studio();
            }
            else
            {
       
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            hotel.RoomsRepo.AddNew(room);
            return string.Format(OutputMessages.RoomTypeAdded, roomTypeName,hotelName);
        }
        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            if (hotelsRepo.Select(hotelName) == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            IHotel hotel = hotelsRepo.Select(hotelName);

            if (roomTypeName != nameof(DoubleBed)
                && roomTypeName != nameof(Apartment)
                && roomTypeName != nameof(Studio))
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            if (hotelsRepo.Select(roomTypeName) != default)
            {
                return string.Format(OutputMessages.RoomTypeNotCreated);
            }

            IRoom room = hotel.RoomsRepo.Select(roomTypeName);

            if (room.PricePerNight > 0)
            {
                throw new InvalidOperationException(ExceptionMessages.CannotResetInitialPrice);
            }

            room.SetPrice(price);
            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }


        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {

            if (hotelsRepo.All().FirstOrDefault(h => h.Category == category) == default)
            {
                return string.Format(OutputMessages.CategoryInvalid,category);
            }

            var orderedHotel =
                hotelsRepo
                .All()
                .Where(h => h.Category == category)
                .OrderBy(t => t.Turnover)
                .ThenBy(f => f.FullName);

            foreach (var hotel in orderedHotel)
            {
                var selectedRoom = 
                hotel.RoomsRepo
                .All()
                .Where(h => h.PricePerNight > 0)
                .Where(b => b.BedCapacity >= adults + children)
                .OrderBy(c => c.BedCapacity)
                .FirstOrDefault();

                if (selectedRoom != null) 
                {
                    int bookingNumber = hotelsRepo
                        .All()
                        .Sum(h => h.BookingsRepo.All().Count) + 1;
                    IBooking booking = new Booking(selectedRoom, duration, adults, children, bookingNumber);
                    hotel.BookingsRepo.AddNew(booking);
                    return string.Format(OutputMessages.BookingSuccessful, bookingNumber, hotel.FullName);
                }
            }
            return string.Format(OutputMessages.RoomNotAppropriate);

        }

        public string HotelReport(string hotelName)
        {
            IHotel hotel = hotelsRepo.Select(hotelName);

            if (hotel == default)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            StringBuilder sb = new StringBuilder(); 

            sb.AppendLine($"Hotel name: {hotelName}");  
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {(hotel.Turnover):f2} $");
            sb.AppendLine("--Bookings:");
            sb.AppendLine();

            if (hotel.BookingsRepo.All().Count == 0)
            {
                sb.AppendLine("none");
            }
            else 
            {
                foreach (var booking in hotel.BookingsRepo.All())
                {
                    sb.AppendLine($"{booking.BookingSummary()}");
                    sb.AppendLine();
                }
            }
            
            return sb.ToString().Trim();
        }


    }

}
