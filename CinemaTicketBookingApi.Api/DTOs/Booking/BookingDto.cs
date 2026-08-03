namespace CinemaTicketBookingApi.Api.Dtos;

public class BookingDto
{
    public int Id { get; set; }
    public DateTime BookingDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public int CustomerId { get; set; }
    public int ShowId { get; set; }
}