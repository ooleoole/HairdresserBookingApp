using Domain.Entities;
using Domain.Entities.Junctions;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class HairdresserBookingAppContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Costumer> Costumers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<WorksAt> WorksAtRealtions { get; set; }
        public DbSet<CompanyCostumer> CompanyCostumers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HairdresserBookingApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasAlternateKey(e => e.SocialSecurityNumber);
            modelBuilder.Entity<Costumer>().HasAlternateKey(c => new { c.FirstName, c.LastName, c.AddressId });
            modelBuilder.Entity<Company>().HasAlternateKey(c => c.Name);
            modelBuilder.Entity<CompanyCostumer>().HasKey(cc => new { cc.CompanyId, cc.CostumerId });
            modelBuilder.Entity<WorksAt>().HasKey(wa => new { wa.CompanyId, wa.EmployeeId });
        }
    }
}
