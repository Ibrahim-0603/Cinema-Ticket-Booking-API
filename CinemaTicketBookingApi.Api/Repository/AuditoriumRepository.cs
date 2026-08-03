using CinemaTicketBookingApi.Api.Data;
using CinemaTicketBookingApi.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketBookingApi.Api.Repositories;

public class AuditoriumRepository : IAuditoriumRepository
{
      private readonly AppDbContext _context;
      public AuditoriumRepository(AppDbContext context)
      {
            _context = context;
      }
      public IQueryable<Auditorium> Query() => _context.Auditoriums.AsNoTracking();
      public async Task<Auditorium?> GetById(int id) => await _context.Auditoriums.FirstOrDefaultAsync(a => a.Id == id);
      public async Task<Auditorium> AddAuditorium(Auditorium auditorium)
      {
            _context.Auditoriums.Add(auditorium);
            await _context.SaveChangesAsync();
            return auditorium;
      }
      public async Task<Auditorium?> UpdateAuditorium(int id, Auditorium auditorium)
      {
            var current = await GetById(id);
            current.RoomNumber = auditorium.RoomNumber;
            current.Capacity = auditorium.Capacity;
            current.Available = auditorium.Available;
            current.Shows = auditorium.Shows;
            await _context.SaveChangesAsync();
            return current;
      }
      public async Task DeleteAuditorium(int id)
      {
            var current = await GetById(id);
            
            _context.Auditoriums.Remove(current);
            await _context.SaveChangesAsync();
      }

}