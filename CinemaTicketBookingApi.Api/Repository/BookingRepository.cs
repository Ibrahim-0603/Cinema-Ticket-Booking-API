using CinemaTicketBookingApi.Api.Data;
using CinemaTicketBookingApi.Api.Enums;
using CinemaTicketBookingApi.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketBookingApi.Api.Repositories;

public class BookingRepository : IBookingRepository
{
      private readonly AppDbContext _context;
      public BookingRepository(AppDbContext context)
      {
            _context = context;
      }
      public IQueryable<Booking> Query() => _context.Bookings.AsNoTracking();
      public async Task<Booking?> GetById(int id) => await _context.Bookings.Include(b => b.Show).Include(b => b.Customer).FirstOrDefaultAsync(a => a.Id == id);
      public async Task<Booking> AddBooking(Booking booking)
      {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
      }
      public async Task<Booking?> UpdateBooking(int id, BookingStatus status)
      {
            var current = await GetById(id);
            current.Status = status;
            await _context.SaveChangesAsync();
            return current;
      }
      public async Task DeleteBooking(int id)
      {
            var current = await GetById(id);

            _context.Bookings.Remove(current);
            await _context.SaveChangesAsync();
      }

}