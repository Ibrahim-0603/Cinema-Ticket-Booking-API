using CinemaTicketBookingApi.Api.Data;
using CinemaTicketBookingApi.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketBookingApi.Api.Repositories;

public class ShowRepository : IShowRepository
{
      private readonly AppDbContext _context;
      public ShowRepository(AppDbContext context)
      {
            _context = context;
      }
      public IQueryable<Show> Query() => _context.Shows.AsNoTracking();
      public async Task<Show?> GetById(int id) => await _context.Shows.Include(s => s.Bookings).FirstOrDefaultAsync(s => s.Id == id);
      public async Task<Show> AddShow(Show show)
      {
            _context.Shows.Add(show);
            await _context.SaveChangesAsync();
            return show;
      }
      public async Task<Show?> UpdateShow(int id, Show show)
      {
            var current = await GetById(id);
            current.ShowTime = show.ShowTime;
            current.MovieId = show.MovieId;
            current.AuditoriumId = show.AuditoriumId;
            await _context.SaveChangesAsync();
            return current;
      }
      public async Task DeleteShow(int id)
      {
            var current = await GetById(id);
            _context.Shows.Remove(current);
            await _context.SaveChangesAsync();
      }
}