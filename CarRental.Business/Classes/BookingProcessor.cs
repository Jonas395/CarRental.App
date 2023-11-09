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


        public void ReturnVehicle(int id, double distance)
        {
            var booking = GetBookings().FirstOrDefault(b => b.Id == id);
            if (booking == null)
            {
                throw new ArgumentNullException();
            }
            if (distance < booking.Vehicle.Odometer)
            {
                throw new ArgumentOutOfRangeException(nameof(distance));
            }
            else booking.DistanceEnd = distance;


            booking.EndDate = DateOnly.FromDateTime(DateTime.Now);
            GetCost(booking);
            

            booking.Vehicle.Odometer = distance;
            booking.Status = Common.Enums.BookingStatus.Returned;
            booking.Vehicle.Status = Common.Enums.VehicleStatus.Available;
        }
        
        
        public void GetCost(IBooking booking)
        {
            double cost = booking.Vehicle.PriceDay + (DayDifference(booking.StartDate, booking.EndDate) * booking.Vehicle.PriceDay) + 
                ((booking.DistanceEnd - booking.DistanceStart) * booking.Vehicle.PriceDistance * 0.1);
            cost = Math.Round(cost, 2);
            booking.Cost = cost;
        }
        
        
        public int DayDifference(DateOnly start, DateOnly? end)
        {
            if(end == null)
            {
                throw new ArgumentNullException(nameof(end));
            }
            var endstring = end.ToString();
            DateOnly enddateonly = DateOnly.Parse(endstring);
            if (start > end)
            {
                throw new ArgumentOutOfRangeException();
            }
            var daysDifference = enddateonly.DayNumber - start.DayNumber;
            return daysDifference;
        }
    }
}