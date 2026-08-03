using CinemaTicketBookingApi.Api.Models;

namespace CinemaTicketBookingApi.Api.Services;

public interface IShowService
{
      public Task<PagedResult<Show>> GetAllShows(PaginationParams paginationParams);
      public Task<Show> GetShowById(int id);
      public Task<Show>CreateShow(Show show);
      public Task UpdateShow (int id, Show show);
      public Task DeleteShow (int id);
}