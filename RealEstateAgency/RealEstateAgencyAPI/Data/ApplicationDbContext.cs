using Microsoft.EntityFrameworkCore;
using RealEstateAgencyAPI.Models;

namespace RealEstateAgencyAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Property> Properties { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Property>().HasData(
                new Property{
                    Id = 1,
                    Name = "Beach House",
                    SquareMeters = 76,
                    Details = "50 meters from the beach",
                    ImageURL = "https://i.pinimg.com/1200x/4d/37/32/4d37324143b5f5a0ecca431b66a60e12.jpg",
                    Type = "House",
                    Address = "Stadiou Street 7",
                    City = "Kavos",
                    Country = "Greece",
                    CreatedDate = DateTime.Now
                },
                new Property
                {
                    Id = 2,
                    Name = "NYC Appartment",
                    SquareMeters = 83,
                    Details = "5th floor",
                    ImageURL = "https://images1.apartments.com/i2/gV9g9N4i55VYrA8JKF-ECZVproGO3WaVB8FQpuKY7DQ/111/746-9th-ave-new-york-ny-primary-photo.jpg",
                    Type = "Appartment",
                    Address = "9th Avenue 143",
                    City = "New York City",
                    Country = "United States of America",
                    CreatedDate = DateTime.Now
                },
                new Property
                {
                    Id = 3,
                    Name = "Industrial warehouse",
                    SquareMeters = 3267,
                    Details = "Suburbs of Novi Sad",
                    ImageURL = "https://m3.spitogatos.gr/259892801_300x220.jpg?v=20130730",
                    Type = "Warehouse",
                    Address = "Partizanska 34",
                    City = "Novi Sad",
                    Country = "Serbia",
                    CreatedDate = DateTime.Now
                }
            );
        }
    }
}
