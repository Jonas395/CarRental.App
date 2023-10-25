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
        
        
        public void ReturnVehicle(int id, double distance)
        {
            var booking = GetBookings().FirstOrDefault(b => b.Id == id);
            CheckDistance(booking, distance);
            booking.Distance = distance;
            CheckDate(booking);
            booking.EndDate = DateToday();
            GetCost(booking, distance);
            CheckStatus(booking);

            booking.Vehicle.Odometer = distance;
            booking.Status = Common.Enums.BookingStatus.Returned;
            booking.Vehicle.Status = Common.Enums.VehicleStatus.Available;
        }
        public void CheckDistance(IBooking booking, double distance)
        {
            if (distance < booking.Vehicle.Odometer)
            { 
                throw new ArgumentOutOfRangeException(nameof(distance)); 
            } 
        }
        public void CheckDate(IBooking booking)
        {
            if (DayDifference(booking.StartDate, DateToday())<0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        public void CheckStatus(IBooking booking)
        {
            if(booking.Status!=Common.Enums.BookingStatus.Active)
            {
                throw new ArgumentException(nameof(booking.Status));
            }
        }
        public void GetCost(IBooking booking, double distance)
        {
            var dateNow = DateToday();
            var total = (booking.Vehicle.PriceDistance * 0.1) * (distance - booking.Vehicle.Odometer) + (DayDifference(booking.StartDate, dateNow) * booking.Vehicle.PriceDay);
            booking.Cost = Math.Round(total, 2);
        }
        public DateOnly DateToday()
        {
            return DateOnly.FromDateTime(DateTime.Now);
        }
        public int DayDifference(DateOnly start, DateOnly end)
        {
            var daysDifference = end.DayNumber - start.DayNumber;
            return daysDifference;
        }
    }
}