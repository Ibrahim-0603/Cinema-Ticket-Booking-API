namespace CinemaTicketBookingApi.Api.Models;
public class Customer
{
      public int Id {get; set;}
      public string Name {get; set;}
      public string Email {get; set;}
      public IEnumerable<Booking> Bookings {get; set;} = new List<Booking>();
}