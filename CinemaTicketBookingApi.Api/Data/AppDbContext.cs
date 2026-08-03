using CinemaTicketBookingApi.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketBookingApi.Api.Data;

public class AppDbContext : DbContext
{
      public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
      public DbSet<Auditorium> Auditoriums => Set<Auditorium>();
      public DbSet<Booking> Bookings => Set<Booking>();
      public DbSet<Customer> Customers => Set<Customer>();
      public DbSet<Movie> Movies => Set<Movie>();
      public DbSet<Show> Shows => Set<Show>();

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
            modelBuilder.Entity<Show>(entity =>
            {
                  entity.HasKey(s => s.Id);
                  entity.Property(s => s.ShowTime).IsRequired();

                  entity.HasOne(s => s.Movie)
                  .WithMany(m => m.Shows)
                  .HasForeignKey(s => s.MovieId)
                  .OnDelete(DeleteBehavior.Restrict);

                  entity.HasOne(s => s.Auditorium)
                  .WithMany(a => a.Shows)
                  .HasForeignKey(s => s.AuditoriumId)
                  .OnDelete(DeleteBehavior.Restrict);

                  entity.HasMany(s => s.Bookings)
                  .WithOne(b => b.Show)
                  .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Booking>(entity =>
            {
                  entity.HasKey(b => b.Id);
                  entity.Property(b => b.BookingDate).IsRequired();
                  entity.Property(b => b.Status).IsRequired();

                  entity.HasOne(c => c.Customer)
                  .WithMany(b => b.Bookings)
                  .HasForeignKey(b => b.CustomerId)
                  .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Customer>(entity =>
            {
                  entity.HasKey(c => c.Id);
                  entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
                  entity.Property(c => c.Email).IsRequired();
            });
            modelBuilder.Entity<Movie>(entity =>
            {
                  entity.HasKey(m => m.Id);
                  entity.HasIndex(m => m.Name).IsUnique();
                  entity.Property(m => m.Genre);
                  entity.Property(m => m.ReleaseDate).IsRequired();
                  entity.Property(m => m.AvailableInCinema).IsRequired();
            });
      }
}