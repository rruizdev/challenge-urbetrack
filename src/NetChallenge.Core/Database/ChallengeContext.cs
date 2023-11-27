using Microsoft.EntityFrameworkCore;
using NetChallenge.Core.Domain;

namespace NetChallenge.Core.Database
{
    public class ChallengeContext : DbContext
    {
        public ChallengeContext(DbContextOptions<ChallengeContext> options) : base(options) { }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Office> Offices { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<OfficeResource> OfficeResources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                .HasKey(loc => loc.Name);

            modelBuilder.Entity<Resource>()
                .HasKey(res => res.Name);
            modelBuilder.Entity<Resource>()
                .HasMany(res => res.OfficeResources)
                .WithOne(ore => ore.Resource)
                .HasForeignKey(res => res.ResourceName);

            modelBuilder.Entity<Office>()
                .HasKey(of => of.Id);
            modelBuilder.Entity<Office>()
                .HasAlternateKey(off => new { off.Name, off.LocationName });
            modelBuilder.Entity<Office>()
                .HasOne(off => off.Location)
                .WithMany(loc => loc.Offices)
                .HasForeignKey(off => off.LocationName);
            modelBuilder.Entity<Office>()
                .HasMany(off => off.OfficeResources)
                .WithOne(or => or.Office)
                .HasForeignKey(off => off.OfficeId);

            modelBuilder.Entity<Booking>()
                .HasKey(bo => bo.Id);
            modelBuilder.Entity<Booking>()
                .HasOne(bo => bo.Office)
                .WithMany()
                .HasForeignKey(bo => bo.OfficeId);

            modelBuilder.Entity<OfficeResource>()
                .HasKey(ofr => new { ofr.OfficeId, ofr.ResourceName });
            modelBuilder.Entity<OfficeResource>()
                .HasOne(or => or.Office)
                .WithMany(o => o.OfficeResources)
                .HasForeignKey(or => or.OfficeId);
            modelBuilder.Entity<OfficeResource>()
                .HasOne(or => or.Resource)
                .WithMany(r => r.OfficeResources)
                .HasForeignKey(or => or.ResourceName);
        }
    }
}