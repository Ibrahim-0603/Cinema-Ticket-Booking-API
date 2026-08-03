using CinemaTicketBookingApi.Api.Models;

namespace CinemaTicketBookingApi.Api.Repositories;

public interface IAuditoriumRepository
{
      IQueryable<Auditorium> Query();
      Task<Auditorium?> GetById(int id);
      Task<Auditorium> AddAuditorium(Auditorium auditorium);
      Task<Auditorium?> UpdateAuditorium(int id, Auditorium auditorium);
      Task DeleteAuditorium(int id);
}