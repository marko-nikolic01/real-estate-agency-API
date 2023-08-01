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
    }
}
