namespace CinemaTicketBookingApi.Api.Exceptions;

public class ShowNotFoundException: NotFoundException
{
      public ShowNotFoundException(int id): base($"Show with ID {id} not found"){}
}