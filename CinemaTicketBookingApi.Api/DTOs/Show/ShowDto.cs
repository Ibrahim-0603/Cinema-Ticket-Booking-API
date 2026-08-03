namespace CinemaTicketBookingApi.Api.Dtos;

public class ShowDto
{
    public int Id { get; set; }
    public DateTime ShowTime { get; set; }
    public int MovieId { get; set; }
    public int AuditoriumId { get; set; }
}