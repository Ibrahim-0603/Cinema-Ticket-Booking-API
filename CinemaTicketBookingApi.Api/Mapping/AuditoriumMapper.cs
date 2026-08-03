using CinemaTicketBookingApi.Api.Dtos;
using CinemaTicketBookingApi.Api.Models;

namespace CinemaTicketBookingApi.Api.Mapping;

public static class AuditoriumMapper
{
      public static AuditoriumDto ToDto(Auditorium auditorium)
      {
            return new AuditoriumDto
            {
                  Id = auditorium.Id,
                  RoomNumber = auditorium.RoomNumber,
                  Capacity = auditorium.Capacity,
                  Available = auditorium.Available
            };
      }
      public static PagedResult<AuditoriumDto> ToDto(PagedResult<Auditorium> result)
      {
            return new PagedResult<AuditoriumDto>
            {
                  Data = result.Data.Select(a => ToDto(a)),
                  Page = result.Page,
                  PageSize = result.PageSize,
                  TotalCount = result.TotalCount
            };
      }
      public static Auditorium ToEntity(CreateAuditoriumDto dto)
      {
            return new Auditorium
            {
                  RoomNumber = dto.RoomNumber,
                  Capacity = dto.Capacity,
                  Available = dto.Available
            };
      }

}