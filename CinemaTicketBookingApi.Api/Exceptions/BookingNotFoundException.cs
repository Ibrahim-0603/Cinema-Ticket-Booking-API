namespace CinemaTicketBookingApi.Api.Exceptions;

public class BookingNotFoundException: NotFoundException
{
      public BookingNotFoundException(int id): base($"Booking with ID {id} not found."){}
}