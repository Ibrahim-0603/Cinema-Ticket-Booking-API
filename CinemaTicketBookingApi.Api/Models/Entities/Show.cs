
namespace CinemaTicketBookingApi.Api.Models;
public class Show
{
      public int Id {get; set;}
      public DateTime ShowTime {get; set;}
      public int MovieId {get; set;}
      public int AuditoriumId {get; set;}
      public Movie Movie {get; set;} = new Movie();
      public Auditorium Auditorium {get; set;} = new Auditorium();
      public ICollection<Booking> Bookings{get; set;} = new List <Booking>(); 
      
}