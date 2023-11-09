using CarRental.Data.Interfaces;
using CarRental.Common.Interfaces;
using CarRental.Common.Classes;

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
                Model = "911",
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
                Model = "Hilux",
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
                Model = "Kodiak",
                PriceDay = 12,
                PriceDistance = 3,
                Odometer = 45456.5,
                Registration = "ABC 132",
                Status = Common.Enums.VehicleStatus.Available,
                Type = Common.Enums.VehicleType.ATV
            };
            IVehicle vehicle4 = new Car
            {
                Id = 4,
                Model = "911",
                PriceDay = 12,
                PriceDistance = 2,
                Odometer = 32456.5,
                Registration = "ACB 321",
                Status = Common.Enums.VehicleStatus.Booked,
                Type = Common.Enums.VehicleType.Sport
            };
            IVehicle vehicle5 = new Car
            {
                Id = 5,
                Model = "P45",
                PriceDay = 6,
                PriceDistance = 2,
                Odometer = 184648.3,
                Registration = "ACB 312",
                Status = Common.Enums.VehicleStatus.Available,
                Type = Common.Enums.VehicleType.Compact
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

            _bookings.Add(new Booking(1, vehicle4, customer2, Common.Enums.BookingStatus.Active, new DateOnly(2023, 11, 1), 
                null, vehicle4.Odometer, vehicle4.Odometer, null));
            _bookings.Add(new Booking(2, vehicle3, customer1, Common.Enums.BookingStatus.Returned, new DateOnly(2023, 10, 27), new DateOnly(2023, 10, 29),
                vehicle3.Odometer, vehicle3.Odometer + 500, (vehicle3.PriceDay * 3) + (0.1 * 500 * vehicle3.PriceDistance)));

        }
        public IEnumerable<IBooking> GetBookings() => _bookings;
        public IEnumerable<ICustomer> GetCustomers() => _customers;
        public IEnumerable<IVehicle> GetVehicles() => _vehicles;
    }
}
