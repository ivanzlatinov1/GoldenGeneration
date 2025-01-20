using GoldenGeneration.Infrastructure.Entities;
using GoldenGeneration.Infrastructure.Entities.JoinedEntities;
using Microsoft.EntityFrameworkCore;

namespace GoldenGeneration.Infrastructure
{
    public class GoldenGenerationDbContext : DbContext
    {
        //public GoldenGenerationDbContext(DbContextOptions<GoldenGenerationDbContext> opt)
        //    : base(opt)
        //{
        //}
        public required DbSet<Position> Positions { get; set; }
        public required DbSet<Footballer> Footballers { get; set; }
        public required DbSet<Kit> Kits { get; set; }
        public required DbSet<Club> Clubs { get; set; }
        public required DbSet<League> League { get; set; }
        public required DbSet<Manager> Managers { get; set; }
        public required DbSet<ManagerClub> ManagersClubs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=GoldenGeneration;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ManagerClub>()
                .HasKey(mc => new { mc.ManagerId, mc.ClubId });

            modelBuilder.Entity<ManagerClub>()
                .Property(mc => mc.ManagerId)
                .HasMaxLength(50);

            modelBuilder.Entity<ManagerClub>()
                .Property(mc => mc.ClubId)
                .HasMaxLength(50);

            modelBuilder.Entity<ManagerClub>()
                .HasOne(mc => mc.Manager)
                .WithMany(m => m.ManagerClubs)
                .HasForeignKey(mc => mc.ManagerId);

            modelBuilder.Entity<ManagerClub>()
                .HasOne(mc => mc.Club)
                .WithMany(c => c.ManagerClubs)
                .HasForeignKey(mc => mc.ClubId);
        }
    }
}
