namespace CinemaTicketBookingApi.Api.Models;

public class MovieFilterParams : PaginationParams
{
      public string? Search { get; set; }
      public string? Genre { get; set; }
      public string? Order { get; set; } = "asc";
      public string? SortBy { get; set; } = "Name";
}