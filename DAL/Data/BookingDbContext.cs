using DAL.Entities;
using EntityFramework.Exceptions.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // declaration of a specific model configuration to ensure the accuracy of the generated database
            modelBuilder.Entity<Hotel>(entity =>
            {
                // Defoult DeleteBehavior = Cascade
                entity.HasMany(g => g.Rooms)
                .WithOne(g => g.Hotel)
                .HasForeignKey(g => g.HotelId)
                .IsRequired();

                entity.Property(g => g.Name)
                .HasColumnType("nvarchar(30)");

                entity.Property(g => g.City)
                .HasColumnType("nvarchar(30)");

                entity.Property(g => g.Id)
                .HasColumnType("nvarchar(40)");

                entity.HasKey(p => p.Id);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasOne(g => g.Hotel)
                .WithMany(g => g.Rooms)
                .HasForeignKey(g => g.HotelId)
                .IsRequired();

                entity.HasOne(g => g.User)
                .WithOne(g => g.Room)
                .HasForeignKey<User>(g => g.RoomId)
                .OnDelete(DeleteBehavior.SetNull);

                entity.Property(g => g.Id)
                .HasColumnType("nvarchar(40)");

                entity.HasKey(p => p.Id);
            });

            modelBuilder.Entity<User>(entity =>
            { 
                entity.HasOne(g => g.Room)
                .WithOne(g => g.User)
                .HasForeignKey<Room>(g => g.UserId)
                .OnDelete(DeleteBehavior.SetNull);

                entity.Property(g => g.Name)
                .HasColumnType("nvarchar(20)");

                entity.Property(g => g.Surname)
                .HasColumnType("nvarchar(20)");

                entity.Property(g => g.PhoneNumber)
                .HasColumnType("nvarchar(15)");

                entity.Property(g => g.Password)
                .HasColumnType("nvarchar(40)");

                entity.Property(g => g.Email)
                .HasColumnType("nvarchar(40)");

                entity.Property(g => g.Id)
                .HasColumnType("nvarchar(40)");

                entity.HasKey(p => p.Id);
            });
        }
    }
}
