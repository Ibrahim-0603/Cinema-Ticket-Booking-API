using CinemaTicketBookingApi.Api.Enums;
using CinemaTicketBookingApi.Api.Models;

namespace CinemaTicketBookingApi.Api.Services;

public interface IBookingService
{
      public Task<PagedResult<Booking>> GetAllBookings(BookingFilterParams filterParams);
      public Task<Booking> GetBookingById(int id);
      public Task<Booking> CreateBooking(Booking booking);
      public Task UpdateBooking(int id, BookingStatus status);
      public Task DeleteBooking(int id);
}