using CinemaTicketBookingApi.Api.Models;

namespace CinemaTicketBookingApi.Api.Repositories;

public interface IMovieRepository
{
      IQueryable<Movie> Query();
      Task<Movie?> GetById(int id);
      Task<Movie> AddMovie(Movie movie);
      Task<Movie?> UpdateMovie(int id, Movie movie);
      Task DeleteMovie(int id);
}