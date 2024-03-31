using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private List<IBooking> bookings;

        public BookingRepository()
        {
            bookings = new List<IBooking>();
        }

        public void AddNew(IBooking model)
        {
           bookings.Add(model); 
        }
        public IBooking Select(string criteria)
        {
            return bookings
                .FirstOrDefault(b => b.BookingNumber.ToString() == criteria);
        }

        public IReadOnlyCollection<IBooking> All() =>  bookings;
      

    }
}
