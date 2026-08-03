namespace CinemaTicketBookingApi.Api.Exceptions;

public class CustomerNotFoundException: NotFoundException
{
      public CustomerNotFoundException(int id): base($"Customer with ID {id} not found"){}
}