using System.ComponentModel.DataAnnotations;

namespace CinemaTicketBookingApi.Api.Dtos;

public class CreateBookingDto
{
    [Required]
    public int CustomerId { get; set; }

    [Required]
    public int ShowId { get; set; }
}