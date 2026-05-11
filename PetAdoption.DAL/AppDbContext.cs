using Microsoft.EntityFrameworkCore;
using PetAdoption.DAL.Models;

namespace PetAdoption.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pet> Pets { get; set; }
    }
}