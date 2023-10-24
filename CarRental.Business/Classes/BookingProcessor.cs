using CarRental.Common.Classes;
using CarRental.Common.Interfaces;
using CarRental.Data.Interfaces;
using System.Data;

namespace CarRental.Business.Classes
{
    public class BookingProcessor
    {
        private readonly IData _db;

        public BookingProcessor(IData db)
        {
            _db = db;
        }
        public IEnumerable<IBooking> GetBookings() 
        {
            IEnumerable<IBooking> bookings = _db.GetBookings(); 

            return bookings;   
        }
        public IEnumerable<ICustomer> GetCustomers()
        {
            IEnumerable<ICustomer> customers = _db.GetCustomers();

            return customers;
        }
        public IEnumerable<IVehicle> GetVehicles() 
        {
            IEnumerable<IVehicle> vehicles = _db.GetVehicles();

            return vehicles;
        }
        public void SetDate(int id) { }
    }
}