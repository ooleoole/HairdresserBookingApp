using Domain.Enums;

namespace Domain.Entities
{
    public class Costumer
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public bool NotifyExtraCostOrTime { get; set; }
        public string Notes { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        

    }
}
