using CarRental.Common.Interfaces;

namespace CarRental.Common.Classes
{
    public class Customer : ICustomer
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int SSN { get; set; }
        
    }
}
