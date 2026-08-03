using CinemaTicketBookingApi.Api.Models;

namespace CinemaTicketBookingApi.Api.Services;

public interface IMovieService
{
      public Task<PagedResult<Movie>> GetAllMovies(MovieFilterParams filterParams);
      public Task<Movie> GetMovieById(int id);
      public Task<Movie>CreateMovie(Movie movie);
      public Task UpdateMovie (int id, Movie movie);
      public Task DeleteMovie (int id);
}
