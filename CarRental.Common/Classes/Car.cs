using CarRental.Common.Enums;
using CarRental.Common.Interfaces;

namespace CarRental.Common.Classes
{
    public class Car : IVehicle
    {
        public int Id { get; set; }
        public string Model { get; set; }

        public VehicleStatus Status { get; set; }

        public VehicleType Type { get; set; }

        public string Registration { get; set; }

        public double Odometer { get; set; }

        public double PriceDistance { get; set; }

        public double PriceDay { get; set; }
    }
}
