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
        public DateOnly? EndDate { get; set; }
        public double Distance { get; set; }
        public double? Cost { get; set; }
        public Booking(int id, IVehicle vehicle, ICustomer customer, BookingStatus status, DateOnly start, DateOnly? end, double distance, double? cost) {
            (Id, Vehicle, Customer, Status, StartDate, EndDate, Distance, Cost) = (id, vehicle, customer, status, start, end, distance, cost);
        }
    }
}
