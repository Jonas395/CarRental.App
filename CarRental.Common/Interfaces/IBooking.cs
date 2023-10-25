using CarRental.Common.Enums;

namespace CarRental.Common.Interfaces
{
    public interface IBooking
    {
        public int Id { get; set; }
        public IVehicle? Vehicle { get; set; }
        public ICustomer? Customer { get; set; }
        public BookingStatus Status { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public double Distance { get; set; }
        public double? Cost { get; set; }
    }
}
