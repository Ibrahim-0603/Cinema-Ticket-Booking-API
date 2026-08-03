using System.Transactions;
using CinemaTicketBookingApi.Api.Enums;

namespace CinemaTicketBookingApi.Api.Models;
public class Booking
{
      public int Id {get; set;}
      public DateTime BookingDate {get; set;}
      public BookingStatus Status {get; set;}
      public int CustomerId {get; set;}
      public int ShowId{get; set;}
      public Customer Customer {get; set;} = new Customer();
      public Show Show {get; set;} = new Show();
}