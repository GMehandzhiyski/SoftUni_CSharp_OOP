using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;

namespace BookingApp.Models.Rooms
{
    public abstract class Room : IRoom
    {
        private int bedCapacity;
        private double pricePerNight = 0;

        protected Room(int bedCapacity)
        {
            this.bedCapacity = bedCapacity;
        }
        public int BedCapacity => bedCapacity;
        
        public double PricePerNight
        {
            get { return pricePerNight; }

            set
            {
                if (value < 0)
                {
                  throw new AggregateException(string.Format(ExceptionMessages.PricePerNightNegative));
                }

                pricePerNight = value;
            
            }
        }

        public void SetPrice(double price)
        {
            pricePerNight = price;
        }
    }
}
