using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;

namespace BookingApp.Models.Hotels
{
    public class Hotel : IHotel
    {
        private string fullName;
        private int category;

        public Hotel(string fullName, int category)
        {
            FullName = fullName;
            Category = category;
            RoomsRepo = new RoomRepository();
            BookingsRepo = new BookingRepository();
        }

        public string FullName
        {
            get { return fullName; }

            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.HotelNameNullOrEmpty)); 
                }
                fullName = value;
            }
        }

        public int Category
        {
            get { return category; }

            set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCategory));
                }
                category = value;
            }
        }

        public double Turnover => 
            Math.Round(BookingsRepo
            .All()
            .Sum(x => x.ResidenceDuration * x.Room.PricePerNight),2);
        
        public IRepository<IRoom> RoomsRepo { get; set; }

        public IRepository<IBooking> BookingsRepo { get; set; }
    }
}
