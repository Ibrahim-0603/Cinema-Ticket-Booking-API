namespace CinemaTicketBookingApi.Api.Exceptions;

public class InvalidBookingException: Exception
{
      public InvalidBookingException(string message): base(message){}
}