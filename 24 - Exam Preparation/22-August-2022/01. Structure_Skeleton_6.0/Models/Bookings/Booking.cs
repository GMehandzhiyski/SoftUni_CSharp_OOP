using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        private int residenceDuration;
        private int adultsCount;
        private int childrenCount;
        private int bookingNumber;

        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            Room = room;
            ResidenceDuration = residenceDuration;
            AdultsCount = adultsCount;
            ChildrenCount = childrenCount;
            this.bookingNumber = bookingNumber;
        }

        public IRoom Room { get; private set; }

        public int ResidenceDuration
        {
            get { return residenceDuration; }
            set 
            {
                if (value < 1)
                {
                    throw new AggregateException(string.Format(ExceptionMessages.DurationZeroOrLess));
                }

                residenceDuration = value;
            }
        }

        public int AdultsCount
        {
            get { return adultsCount; }
            set
            {
                if (value < 1)
                {
                    throw new AggregateException(string.Format(ExceptionMessages.AdultsZeroOrLess));
                }

                adultsCount = value;
            }
        }

        public int ChildrenCount
        {
            get { return childrenCount; }
            set
            {
                if (value < 0)
                {
                    throw new AggregateException(string.Format(ExceptionMessages.ChildrenNegative));
                }

                childrenCount = value;
            }
        }
        public int BookingNumber => bookingNumber;

        public string BookingSummary()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Booking number: {BookingNumber}");
            sb.AppendLine($"Room type: {Room.GetType().Name}");
            sb.AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}");
            var totalPrice = Math.Round(ResidenceDuration * Room.PricePerNight, 2);
            sb.AppendLine($"Total amount paid: {totalPrice:f2} $");

                return sb.ToString().Trim();
        }
    }
}
