using CinemaTicketBookingApi.Api.Exceptions;
using CinemaTicketBookingApi.Api.Models;
using CinemaTicketBookingApi.Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketBookingApi.Api.Services;

public class MovieService : IMovieService
{
      private readonly IMovieRepository _movieRepository;
      public MovieService(IMovieRepository movieRepository)
      {
            _movieRepository = movieRepository;
      }

      public async Task<PagedResult<Movie>> GetAllMovies(MovieFilterParams filterParams)
      {
            var query = _movieRepository.Query();
            if (!string.IsNullOrWhiteSpace(filterParams.Search))
            {
                  query = query.Where(m => m.Name.Contains(filterParams.Search, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrWhiteSpace(filterParams.Genre))
            {
                  query = query.Where(m => m.Genre == filterParams.Genre);
            }
            string order = filterParams.Order;
            string sortBy = filterParams.SortBy;
            if (sortBy == "Name")
            {
                  query = order == "asc" ? query.OrderBy(m => m.Name) : query.OrderByDescending(m => m.Name);
            }
            else if (sortBy == "ReleaseDate")
            {
                  query = order == "asc" ? query.OrderBy(m => m.ReleaseDate) : query.OrderByDescending(m => m.ReleaseDate);
            }
            var totalCount = await query.CountAsync();
            query = query.Skip((filterParams.Page - 1) * filterParams.PageSize).Take(filterParams.PageSize);
            var movies = await query.ToListAsync();

            return new PagedResult<Movie>
            {
                  Data = movies,
                  Page = filterParams.Page,
                  PageSize = filterParams.PageSize,
                  TotalCount = totalCount
            };
      }

      public async Task<Movie> GetMovieById(int id)
      {
            var movie = await _movieRepository.GetById(id);
            if (movie == null) throw new MovieNotFoundException(id);
            return movie;
      }
      public async Task<Movie> CreateMovie(Movie movie)
      {
            var movies = _movieRepository.Query();
            if (await movies.AnyAsync(m => m.Name == movie.Name))
            {
                  throw new MovieAlreadyExistsException(movie.Name);
            }
            var newMovie = await _movieRepository.AddMovie(movie);
            return newMovie;
      }
      public async Task UpdateMovie(int id, Movie movie)
      {
            await GetMovieById(id);
            await _movieRepository.UpdateMovie(id, movie);
      }
      public async Task DeleteMovie(int id)
      {
            var movie = await GetMovieById(id);
            if (movie.Shows.Any())
            {
                  throw new InvalidOperationException($"Movie with ID {id} cannot be deleted because it has active shows");
            }
            await _movieRepository.DeleteMovie(id);
      }

}