using System.ComponentModel.DataAnnotations;

namespace CinemaTicketBookingApi.Api.Dtos;

public class CreateMovieDto
{
      [Required]
      [MaxLength(200)]
      public string Name { get; set; } = string.Empty;
      [Required]
      public string Genre { get; set; } = string.Empty;
      [Required]
      public DateTime ReleaseDate { get; set; }
      public bool AvailableInCinema { get; set; }
}