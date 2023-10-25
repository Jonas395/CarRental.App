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
        public int DayDifference(DateOnly start, DateOnly end) 
        {
            var daysDifference = end.DayNumber - start.DayNumber;
            return daysDifference;
        }
        public double GetCost(int id, double distance) 
        {
            var booking = GetBookings().FirstOrDefault(b => b.Id == id);
            var dateNow = DateOnly.FromDateTime(DateTime.Now);
            booking.EndDate = dateNow;
            var total = (booking.Vehicle.PriceDistance * 0.1) * (distance - booking.Vehicle.Odometer) + (DayDifference(booking.StartDate, dateNow) * booking.Vehicle.PriceDay);

            return total = Math.Round(total, 2);
        }
        public DateOnly SetEndDate( int id)
        {
            var booking = GetBookings().FirstOrDefault(b => b.Id == id);
            var dateNow = DateOnly.FromDateTime(DateTime.Now);
            booking.EndDate = dateNow;
            return dateNow;
        }
    }
}