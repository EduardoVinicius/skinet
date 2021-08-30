
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    // Class responsible for representing a session with the Database.
    // It allows us to query and save instances of our entities to the DB.
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }
        
        // The following properties represents the tables in the Database.
        // The entities stored in the tables are of the type specified in the DbSet<>.
        public DbSet<Product> Products { get; set; }
    }
}