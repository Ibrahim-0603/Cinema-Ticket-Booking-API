namespace CinemaTicketBookingApi.Api.Models;
public class Show
{
      public int Id {get; set;}
      public DateTime ShowTime {get; set;}
      
      public string MovieId {get; set;}
      public string AuditoriumId {get; set;}
      public IEnumerable<Movie> Movies {get; set;} = new List<Movie>();
      public IEnumerable<Auditorium> Auditoriums {get; set;} = new List<Auditorium>();
      public IEnumerable<Booking> Bookings{get; set;} = new List <Booking>(); 
      
}