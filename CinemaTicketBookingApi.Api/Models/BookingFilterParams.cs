using CinemaTicketBookingApi.Api.Enums;

namespace CinemaTicketBookingApi.Api.Models;

public class BookingFilterParams : PaginationParams
{
      public int? CustomerId { get; set; }
      public string? CustomerName { get; set; }
      public int? ShowId { get; set; }
      public BookingStatus? Status { get; set; }
}