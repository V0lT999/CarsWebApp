
using CarsWebApp.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace CarsWebApp.DAL
{
    public class AppContext : DbContext
    {
        public DbSet<Car> Car { get; set; }
        public DbSet<Dealer> Dealer { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<Buyer> Buyer { get; set; }
        public DbSet<City> City { get; set; }
        
        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
            // Database.EnsureDeleted();   // создаем базу данных при первом обращении
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
    }
}
