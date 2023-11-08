using CarRental.Common.Enums;
namespace CarRental.Common.Interfaces
{
    public interface IVehicle
    {
        public int Id { get; set; }
        public string? Model { get; set; }
        VehicleStatus Status { get; set; }
        VehicleType Type { get; set; }
        string? Registration { get; set; }
        double Odometer { get; set; }
        double PriceDistance { get; set; }
        double PriceDay { get; set; }
    }
}
