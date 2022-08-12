using IneorTaskBackend.Model;
using IneorTaskBackend.Helpers;
using IneorTaskBackend.Model.Login;
using Microsoft.EntityFrameworkCore;

namespace IneorTaskBackend.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Beach> Beaches { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beach>(entity =>
            {
                entity.Property(e => e.Id)
                    .IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.ImageUrl)
                    .IsRequired();

                entity.Property(e => e.Country)
                    .IsRequired();

                entity.ToTable("beaches");
                entity.HasData(SeedHelper.GetBeachesSeedData());
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id)
                    .IsRequired();

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Role);

                entity.ToTable("users");
                entity.HasData(SeedHelper.GetUsersSeedData());
            });
        }
    }
}
