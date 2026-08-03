using System.ComponentModel.DataAnnotations;

namespace CinemaTicketBookingApi.Api.Dtos;

public class CreateAuditoriumDto
{
      [Required]
      public int RoomNumber { get; set; }
      [Required]
      public int Capacity { get; set; }
      public bool Available { get; set; }
}