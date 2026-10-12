using ClubCaseStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubCaseStudy.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Memberr> Memberrs { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<MemberShip> MemberShips { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Memberr>()
                .HasOne(x => x.MemberShip)
                .WithOne(c => c.Member)
                .HasForeignKey<MemberShip>(x => x.MemberId);

            modelBuilder.Entity<Booking>()
                .HasOne(x=>x.Member)
                .WithMany(c=>c.Bookings)
                .HasForeignKey(x => x.MemberId);

              modelBuilder.Entity<Booking>()
               .HasOne(x => x.Facility)
               .WithMany(c => c.Bookings)
               .HasForeignKey(x => x.FacilityId);


            modelBuilder.Entity<Payment>()
                .HasOne(c=>c.MemberShip)
                .WithMany(c=>c.Payments)
                .HasForeignKey(x=>x.MembershipId);

            

        }

    }
}
