using Microsoft.EntityFrameworkCore;
using TouriceDatabases.Modals;

namespace TouriceDatabases
{
    public class TouriceDatabaseContext:DbContext
    {

        public TouriceDatabaseContext(DbContextOptions<TouriceDatabaseContext> option):base(option)
        {
            
        }
        public DbSet<tblUser> UserLoginTable { get; set; }
        public DbSet<tblUser> user { get; set; }
        public DbSet<tblbus> Buses { get; set; }
        public DbSet<tblBusDriver> BusDrivers { get; set; }
        
    }
}