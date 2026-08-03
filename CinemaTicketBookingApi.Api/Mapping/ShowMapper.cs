using CinemaTicketBookingApi.Api.Dtos;
using CinemaTicketBookingApi.Api.Models;

namespace CinemaTicketBookingApi.Api.Mapping;

public static class ShowMapper
{
    public static ShowDto ToDto(Show show)
    {
        return new ShowDto
        {
            Id = show.Id,
            ShowTime = show.ShowTime,
            MovieId = show.MovieId,
            AuditoriumId = show.AuditoriumId
        };
    }

    public static PagedResult<ShowDto> ToDto(PagedResult<Show> result)
    {
        return new PagedResult<ShowDto>
        {
            Data = result.Data.Select(m => ToDto(m)),
            Page = result.Page,
            PageSize = result.PageSize,
            TotalCount = result.TotalCount
        };
    }

    public static Show ToEntity(CreateShowDto dto)
    {
        return new Show
        {
            ShowTime = dto.ShowTime,
            MovieId = dto.MovieId,
            AuditoriumId = dto.AuditoriumId
        };
    }
}