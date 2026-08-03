namespace CinemaTicketBookingApi.Api.Exceptions;

public class AuditoriumNotFoundException: NotFoundException
{
      public AuditoriumNotFoundException(int id): base($"Auditorium with ID {id} not found."){}
}