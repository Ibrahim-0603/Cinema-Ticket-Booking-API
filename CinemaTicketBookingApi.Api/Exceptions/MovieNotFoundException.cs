namespace CinemaTicketBookingApi.Api.Exceptions;

public class MovieNotFoundException: NotFoundException
{
      public MovieNotFoundException(int id): base($"Movie with ID {id} not found."){}
}