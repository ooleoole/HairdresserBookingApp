using Domain;
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

        public DbSet<CompanyCostumer> CompanyCostumers { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HairdresserBookingApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HairDresser>().HasAlternateKey(h => h.SocialSecurityNumber);
            modelBuilder.Entity<Costumer>().HasAlternateKey(c => new { c.FirstName, c.LastName, c.AddressId });
            modelBuilder.Entity<Company>().HasAlternateKey(c => c.Name);
            modelBuilder.Entity<CompanyCostumer>().HasKey(cc => new { cc.CompanyId, cc.CostumerId });
            modelBuilder.Entity<Skill>().HasAlternateKey(s => s.Type);
            modelBuilder.Entity<Employee>().HasKey(e => new { e.CompanyId, e.HairDresserId, e.EmploymentNumber });
            modelBuilder.Entity<MasteredSkill>().HasKey(m => new { m.HairDresserId, m.SkillId });
            modelBuilder.Entity<Treatment>().HasAlternateKey(t => new {t.EmployeeId, t.SkillId, t.CompanyId});

        }
    }
}
