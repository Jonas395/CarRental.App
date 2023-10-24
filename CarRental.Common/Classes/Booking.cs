using CarRental.Common.Enums;
using CarRental.Common.Interfaces;

namespace CarRental.Common.Classes
{
    public class Booking : IBooking
    {
        public int Id { get; set; }
        public IVehicle Vehicle { get; set; }
        public ICustomer Customer { get; set; }
        public BookingStatus Status { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int Cost { get; init; }
    }
}
