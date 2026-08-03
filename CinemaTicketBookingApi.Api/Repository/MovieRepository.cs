using CinemaTicketBookingApi.Api.Data;
using CinemaTicketBookingApi.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketBookingApi.Api.Repositories;

public class MovieRepository : IMovieRepository
{
      private readonly AppDbContext _context;
      public MovieRepository(AppDbContext context)
      {
            _context = context;
      }


      public IQueryable<Movie> Query() => _context.Movies.AsNoTracking();
      public async Task<Movie?> GetById(int id) => await _context.Movies.Include(m => m.Shows).FirstOrDefaultAsync(m => m.Id == id);
      public async Task<Movie> AddMovie(Movie movie)
      {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
      }
      public async Task<Movie?> UpdateMovie(int id, Movie movie)
      {
            var current = await GetById(id);
            current.Name = movie.Name;
            current.Genre = movie.Genre;
            current.ReleaseDate = movie.ReleaseDate;
            current.AvailableInCinema = movie.AvailableInCinema;
            current.Shows = movie.Shows;
            await _context.SaveChangesAsync();
            return current;
      }
      public async Task DeleteMovie(int id)
      {
            var current = await GetById(id);
            _context.Movies.Remove(current);
            await _context.SaveChangesAsync();
      }
}