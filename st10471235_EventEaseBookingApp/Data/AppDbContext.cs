using st10471235_EventEaseBookingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace st10471235_EventEaseBookingApp.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Venue> Venues => Set<Venue>();
        public DbSet<Event> Events => Set<Event>();
        public DbSet<Booking> Bookings => Set<Booking>();
        public DbSet<CustomerRequest> CustomerRequests => Set<CustomerRequest>();
    }
}