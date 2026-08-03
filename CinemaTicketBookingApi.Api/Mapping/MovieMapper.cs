using CinemaTicketBookingApi.Api.Dtos;
using CinemaTicketBookingApi.Api.Models;

namespace CinemaTicketBookingApi.Api.Mapping;

public static class MovieMapper
{
    public static MovieDtoV1 ToDtoV1(Movie movie)
    {
        return new MovieDtoV1
        {
            Id = movie.Id,
            Name = movie.Name,
            AvailableInCinema = movie.AvailableInCinema
        };
    }
    public static PagedResult<MovieDtoV1> ToDtoV1 (PagedResult<Movie> result){
        return new PagedResult<MovieDtoV1>
        {
        Data = result.Data.Select(m => ToDtoV1(m)),
        Page = result.Page,
        PageSize = result.PageSize,
        TotalCount = result.TotalCount
        };
    }
    public static MovieDtoV2 ToDtoV2(Movie movie)
    {
        return new MovieDtoV2
        {
            Id = movie.Id,
            Name = movie.Name,
            AvailableInCinema = movie.AvailableInCinema,
            Genre = movie.Genre,
            ReleaseDate = movie.ReleaseDate
        };
    }
        public static PagedResult<MovieDtoV2> ToDtoV2 (PagedResult<Movie> result){
        return new PagedResult<MovieDtoV2>
        {
        Data = result.Data.Select(m => ToDtoV2(m)),
        Page = result.Page,
        PageSize = result.PageSize,
        TotalCount = result.TotalCount
        };
    }

    public static Movie ToEntity(CreateMovieDto dto)
    {
        return new Movie
        {
            Name = dto.Name,
            Genre = dto.Genre,
            AvailableInCinema = dto.AvailableInCinema,
            ReleaseDate = dto.ReleaseDate
        };
    }
}