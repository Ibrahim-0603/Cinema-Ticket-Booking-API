using System.Transactions;

namespace CinemaTicketBookingApi.Api.Models;
public class Booking
{
      public int Id {get; set;}
      public DateTime BookingDate {get; set;}
      public string Status {get; set;}
      public int CustomerId {get; set;}
      public int ShowId{get; set;}
      public IEnumerable<Customer> Customers {get; set;} = new List<Customer>();
      public IEnumerable<Show> Shows {get; set;} = new List<Show>();
}