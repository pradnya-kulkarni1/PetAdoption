using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace PetAdoption.Models
{
    public class SqlDbContext : DbContext
    {
        // The EF model of a database!

        public DbSet<User> Users { get; set; } // represents model of database

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<ReferenceBackground> ReferenceBackgrounds { get; set; }
        public DbSet<ReferencePersonal> ReferencePersonals { get; set; }
        public DbSet<Adoption> Adoption { get; set; }
        public DbSet<AdoptionRequest> AdoptionRequests { get; set; }
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {

        }
    }
}
