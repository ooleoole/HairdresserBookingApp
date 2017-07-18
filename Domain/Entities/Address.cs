using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class Address
    {

        public int Id { get; set; }
        [Required, MinLength(3, ErrorMessage = "Min lenght is 2 chars"), MaxLength(96, ErrorMessage = "Max lenght is 96 chars")]
        public string Street { get; set; }
        [Required, MinLength(2, ErrorMessage = "Min lenght is 2 chars"), MaxLength(50, ErrorMessage = "Max lenght is 50 chars")]
        public string City { get; set; }
        [Required, MinLength(7), MaxLength(8)]
        public string ZipCode { get; set; }
        [MaxLength(96)]
        public string Co { get; set; }

        public IEnumerable<Company> Companies { get; set; } = new List<Company>();
        public IEnumerable<Costumer> Costumers { get; set; } = new List<Costumer>();
        public IEnumerable<Employee> Employees { get; set; } = new List<Employee>();

    }
}
