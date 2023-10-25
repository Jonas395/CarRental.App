using CarRental.Common.Interfaces;

namespace CarRental.Data.Interfaces
{
    public interface IData
    {
        IEnumerable<IBooking> GetBookings();
        IEnumerable<ICustomer> GetCustomers();
        IEnumerable<IVehicle> GetVehicles();
        //IBooking GetBooking(int id);
        //ICustomer GetCustomer(int id);
        //IVehicle GetVehicle(int id);
    }
}
