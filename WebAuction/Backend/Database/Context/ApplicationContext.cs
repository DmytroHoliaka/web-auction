using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAuction.Backend.Database.Entities;

namespace WebAuction.Backend.Database.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Auction> Auctions => Set<Auction>();
        public DbSet<Image> Photos => Set<Image>();
        public DbSet<Bet> Bets => Set<Bet>();
        public DbSet<User> Users => Set<User>();

        public ApplicationContext(DbContextOptions<ApplicationContext> options) :
            base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(ConfigureUser);
            modelBuilder.Entity<Auction>(ConfigureAuction);
            modelBuilder.Entity<Bet>(ConfigureBet);
            modelBuilder.Entity<Image>(ConfigureImage);
        }

        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(u => u.BetedAuctions)
                .WithMany(a => a.Users)
                .UsingEntity<Bet>(
                    j => j
                          .HasOne(b => b.Auction)
                          .WithMany(a => a.Bets)
                          .HasForeignKey(b => b.AuctionId)
                          .OnDelete(DeleteBehavior.Cascade),
                    j => j
                          .HasOne(b => b.User)
                          .WithMany(u => u.Bets)
                          .HasForeignKey(b => b.UserId)
                          .OnDelete(DeleteBehavior.Cascade));

            builder.Property(u => u.FirstName).HasMaxLength(64);
            builder.Property(u => u.LastName).HasMaxLength(64);
            builder.Property(u => u.Password).HasMaxLength(32);
            builder.ToTable("Users");
        }

        private void ConfigureAuction(EntityTypeBuilder<Auction> builder)
        {
            builder
                .HasOne(a => a.Creator)
                .WithMany(u => u.CreatedAuctions)
                .HasForeignKey(a => a.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(a => a.Name).HasMaxLength(32);
            builder.Property(a => a.Name).HasMaxLength(1024);
            builder.Property(a => a.StartPrice).HasColumnType("decimal(10,2)");
            builder.ToTable("Auctions");
        }

        private void ConfigureBet(EntityTypeBuilder<Bet> builder)
        {
            builder.Property(b => b.Price).HasColumnType("decimal(10,2)");
            builder.ToTable("Bets");
        }

        private void ConfigureImage(EntityTypeBuilder<Image> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(32);
            builder.ToTable("Images");
        }
    }
}