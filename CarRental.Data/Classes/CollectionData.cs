using CarRental.Data.Interfaces;
using CarRental.Common.Interfaces;
using CarRental.Common.Classes;
using System.Data;

namespace CarRental.Data.Classes
{
    public class CollectionData : IData
    {
        readonly List<IBooking> _bookings = new List<IBooking>();
        readonly List<ICustomer> _customers = new List<ICustomer>();
        readonly List<IVehicle> _vehicles = new List<IVehicle>();

        public CollectionData() => SeedData();

        void SeedData()
        {
            IVehicle vehicle1 = new Car
            {
                Id = 1,
                Model = "Geoff",
                PriceDay = 20,
                PriceDistance = 5,
                Odometer = 2654.5,
                Registration = "ABC 123",
                Status = Common.Enums.VehicleStatus.Available,
                Type = Common.Enums.VehicleType.Sport
            };
            IVehicle vehicle2 = new Car
            {
                Id = 2,
                Model = "Toybota",
                PriceDay = 40,
                PriceDistance = 5,
                Odometer = 78456.5,
                Registration = "ABC 321",
                Status = Common.Enums.VehicleStatus.Unavailable,
                Type = Common.Enums.VehicleType.OffRoad
            };
            IVehicle vehicle3 = new Bike
            {
                Id = 3,
                Model = "Pro-Rider Road-King",
                PriceDay = 12,
                PriceDistance = 3,
                Odometer = 78456.5,
                Registration = "ABC 132",
                Status = Common.Enums.VehicleStatus.Available,
                Type = Common.Enums.VehicleType.Scooter
            };
            IVehicle vehicle4 = new Car
            {
                Id = 4,
                Model = "Geoff",
                PriceDay = 12,
                PriceDistance = 2,
                Odometer = 32456.5,
                Registration = "ABC 321",
                Status = Common.Enums.VehicleStatus.Rented,
                Type = Common.Enums.VehicleType.Sport
            };
            IVehicle vehicle5 = new Bike
            {
                Id = 5,
                Model = "P45",
                PriceDay = 6,
                PriceDistance = 2,
                Odometer = 184648.3,
                Registration = "ABC 312",
                Status = Common.Enums.VehicleStatus.Available,
                Type = Common.Enums.VehicleType.UltraCompact
            };
            _vehicles.Add(vehicle1);
            _vehicles.Add(vehicle2);
            _vehicles.Add(vehicle3);
            _vehicles.Add(vehicle4);
            _vehicles.Add(vehicle5);
            ICustomer customer1 = new Customer
            {
                Id = 1,
                FirstName = "Billy",
                LastName = "Bobson",
                SSN = 123
            };
            ICustomer customer2 = new Customer
            {
                Id = 2,
                FirstName = "Bob",
                LastName = "Bennyson",
                SSN = 321
            };
            ICustomer customer3 = new Customer
            {
                Id = 3,
                FirstName = "Benny",
                LastName = "Billyson",
                SSN = 132
            };
            _customers.Add(customer1);
            _customers.Add(customer2);
            _customers.Add(customer3);

            _bookings.Add(new Booking(1, vehicle4, customer2, Common.Enums.BookingStatus.Active, new DateOnly(2023, 10, 1), null, null));
            _bookings.Add(new Booking(1, vehicle2, customer1, Common.Enums.BookingStatus.Pending, new DateOnly(2023, 10, 1), null, null));

        }
        public IEnumerable<IBooking> GetBookings() => _bookings;
        public IEnumerable<ICustomer> GetCustomers() => _customers;
        public IEnumerable<IVehicle> GetVehicles() => _vehicles;
        

    }
}
