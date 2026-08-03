namespace CinemaTicketBookingApi.Api.Exceptions;

public class MovieAlreadyExistsException: Exception
{
      public MovieAlreadyExistsException(string name): base($"Movie with name {name} already exists."){}
}