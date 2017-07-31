using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.Junctions;

namespace Domain.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
        public IEnumerable<Costumer> Costumers { get; set; } = new List<Costumer>();
        public IEnumerable<Employee> Employees { get; set; } = new List<Employee>();
        public IEnumerable<Treatment> Treatments { get; set; }= new List<Treatment>();
    }
}

