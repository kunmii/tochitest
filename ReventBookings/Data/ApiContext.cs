using Microsoft.EntityFrameworkCore;
using ReventBookings.Model;

namespace ReventBookings.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<ReventBooking> Bookings { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options): base(options)
        {
        }
    }
}
