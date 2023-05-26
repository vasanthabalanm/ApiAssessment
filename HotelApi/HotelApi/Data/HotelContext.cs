using HotelApi.Model;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Data
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options) 
        {

        }
        //all entities created in model 
        public DbSet<HotelDetails> HotelDetails { get; set; }
        public DbSet<HotelAdmin> HotelAdmins { get; set;}
        public DbSet<CustomerDetails> CustomerDetails { get; set; }
        public DbSet<BookingDetails> BookingDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}
