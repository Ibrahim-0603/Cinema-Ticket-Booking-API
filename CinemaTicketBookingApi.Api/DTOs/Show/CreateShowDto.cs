using System.ComponentModel.DataAnnotations;

namespace CinemaTicketBookingApi.Api.Dtos;

public class CreateShowDto
{
    [Required]
    public DateTime ShowTime { get; set; }

    [Required]
    public int MovieId { get; set; }

    [Required]
    public int AuditoriumId { get; set; }
}