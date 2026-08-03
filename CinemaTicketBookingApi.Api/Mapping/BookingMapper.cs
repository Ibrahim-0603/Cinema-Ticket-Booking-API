using CinemaTicketBookingApi.Api.Dtos;
using CinemaTicketBookingApi.Api.Models;

namespace CinemaTicketBookingApi.Api.Mapping;

public static class BookingMapper
{
      public static BookingDto ToDto(Booking booking)
      {
            return new BookingDto
            {
                  Id = booking.Id,
                  BookingDate = booking.BookingDate,
                  Status = booking.Status.ToString(),
                  CustomerId = booking.CustomerId,
                  ShowId = booking.ShowId
            };
      }
      public static PagedResult<BookingDto> ToDto(PagedResult<Booking> result)
      {
            return new PagedResult<BookingDto>
            {
                  Data = result.Data.Select(b => ToDto(b)),
                  Page = result.Page,
                  PageSize = result.PageSize,
                  TotalCount = result.TotalCount
            };
      }
      public static Booking ToEntity(CreateBookingDto dto)
      {
            return new Booking
            {
                  CustomerId = dto.CustomerId,
                  ShowId = dto.ShowId
            };
      }

}