using CinemaTicketBookingApi.Api.Models;

namespace CinemaTicketBookingApi.Api.Services;

public interface IAuditoriumService
{
      public Task<PagedResult<Auditorium>> GetAllAuditoriums(PaginationParams paginationParams);
      public Task<Auditorium> GetAuditoriumById(int id);
      public Task<Auditorium> CreateAuditorium(Auditorium auditorium);
      public Task UpdateAuditorium(int id, Auditorium auditorium);
      public Task DeleteAuditorium(int id);
}