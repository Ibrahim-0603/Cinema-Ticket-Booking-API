using CinemaTicketBookingApi.Api.Models;

namespace CinemaTicketBookingApi.Api.Repositories;

public interface IShowRepository
{
      IQueryable<Show> Query();
      Task<Show?> GetById(int id);
      Task<Show> AddShow(Show show);
      Task<Show?> UpdateShow(int id, Show show);
      Task DeleteShow(int id);
}