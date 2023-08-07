using Microsoft.EntityFrameworkCore;
using Travel.Models;

namespace Kanini_Toursim.Model
{
    public class KaniniTourismDbContext : DbContext
    {
        public KaniniTourismDbContext(DbContextOptions<KaniniTourismDbContext> options) : base(options)
        {
        }

      //  public DbSet<Activities> Activities { get; set; }
        public DbSet<Admin_User> AdminUsers { get; set; }
        public DbSet<AdminImageGallery> AdminImageGalleries { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<BillingDetails> BillingDetails { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
       // public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Package> Packages { get; set; }
       // public DbSet<Travel> Travels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);
        }
    }
}
