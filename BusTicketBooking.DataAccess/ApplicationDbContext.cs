using BusTicketBooking.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BusTicketBooking.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Bus> Bus { get; set; }
        public DbSet<SeatDetails> SeatDetails { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }

}