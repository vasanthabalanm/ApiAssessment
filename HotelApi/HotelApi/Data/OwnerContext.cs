using HotelApi.AuthUser;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Data
{
    public class OwnerContext : DbContext
    {
        public OwnerContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Owner> Users { get; set; }
    }
}
