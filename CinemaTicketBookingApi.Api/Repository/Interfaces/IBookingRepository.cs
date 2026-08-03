using CinemaTicketBookingApi.Api.Enums;
using CinemaTicketBookingApi.Api.Models;

namespace CinemaTicketBookingApi.Api.Repositories;

public interface IBookingRepository
{
      IQueryable<Booking> Query();
      Task<Booking?> GetById(int id);
      Task<Booking> AddBooking(Booking booking);
      Task<Booking?> UpdateBooking(int id, BookingStatus status);
      Task DeleteBooking(int id);
}