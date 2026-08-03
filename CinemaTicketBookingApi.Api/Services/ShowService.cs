using CinemaTicketBookingApi.Api.Exceptions;
using CinemaTicketBookingApi.Api.Models;
using CinemaTicketBookingApi.Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketBookingApi.Api.Services;

public class ShowService : IShowService
{
      private readonly IShowRepository _showRepository;
      private readonly IMovieService _movieService;
      private readonly IAuditoriumService _auditoriumService;

      public ShowService(
          IShowRepository showRepository,
          IMovieService movieService,
          IAuditoriumService auditoriumService)
      {
            _showRepository = showRepository;
            _movieService = movieService;
            _auditoriumService = auditoriumService;
      }

      public async Task<PagedResult<Show>> GetAllShows(PaginationParams paginationParams)
      {
            var query = _showRepository.Query();

            var totalCount = await query.CountAsync();
            query = query.Skip((paginationParams.Page - 1) * paginationParams.PageSize).Take(paginationParams.PageSize);
            var shows = await query.ToListAsync();

            return new PagedResult<Show>
            {
                  Data = shows,
                  Page = paginationParams.Page,
                  PageSize = paginationParams.PageSize,
                  TotalCount = totalCount
            };
      }
      public async Task<Show> GetShowById(int id)
      {
            var show = await _showRepository.GetById(id);
            if (show == null) throw new ShowNotFoundException(id);
            return show;
      }

      public async Task<Show> CreateShow(Show show)
      {
            await _movieService.GetMovieById(show.MovieId);
            await _auditoriumService.GetAuditoriumById(show.AuditoriumId);
            var newShow = await _showRepository.AddShow(show);
            return newShow;
      }
      public async Task UpdateShow(int id, Show show)
      {
            await GetShowById(id);
            await _movieService.GetMovieById(show.MovieId);
            await _auditoriumService.GetAuditoriumById(show.AuditoriumId);
            await _showRepository.UpdateShow(id, show);
      }
      public async Task DeleteShow(int id)
      {
            var show = await GetShowById(id);
            if (show.Bookings.Any())
            {
                  throw new InvalidOperationException($"Show with ID {id} cannot be deleted because it has active bookings");
            }
            await _showRepository.DeleteShow(id);
      }


}