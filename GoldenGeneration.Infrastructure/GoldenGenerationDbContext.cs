using GoldenGeneration.Infrastructure.Entities;
using GoldenGeneration.Infrastructure.Entities.JoinedEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static GoldenGeneration.Infrastructure.Constants;

namespace GoldenGeneration.Infrastructure
{
    public class GoldenGenerationDbContext(DbContextOptions<GoldenGenerationDbContext> opt) : IdentityDbContext(opt)
    {
        public required DbSet<Position> Positions { get; set; }
        public required DbSet<Footballer> Footballers { get; set; }
        public required DbSet<Kit> Kits { get; set; }
        public required DbSet<Club> Clubs { get; set; }
        public required DbSet<League> League { get; set; }
        public required DbSet<Manager> Managers { get; set; }
        public required DbSet<ManagerClub> ManagersClubs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Manager>()
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Club>()
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Footballer>()
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ManagerClub>()
                .HasKey(mc => new { mc.ManagerId, mc.ClubId });

            modelBuilder.Entity<ManagerClub>()
                .HasOne(mc => mc.Manager)
                .WithMany(m => m.ManagerClubs)
                .HasForeignKey(mc => mc.ManagerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ManagerClub>()
                .HasOne(mc => mc.Club)
                .WithMany(c => c.ManagerClubs)
                .HasForeignKey(mc => mc.ClubId);

            modelBuilder.Entity<IdentityRole>()
                .HasData([
                    new(Admin)
                    {
                        NormalizedName = Admin.ToUpperInvariant(),
                        Id = new("fad1b19d-5333-4633-bd84-d67c64649f65"),
                        ConcurrencyStamp = "42174679-32f1-48b0-9524-0f00791ec760",
                    }
            ]);
        }
    }
}
