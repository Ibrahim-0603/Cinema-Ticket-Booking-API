using CinemaTicketBookingApi.Api.Enums;
using CinemaTicketBookingApi.Api.Exceptions;
using CinemaTicketBookingApi.Api.Models;
using CinemaTicketBookingApi.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace CinemaTicketBookingApi.Api.Services;

public class BookingService : IBookingService
{
      private readonly IBookingRepository _bookingRepository;
      private readonly IShowService _showService;
      private readonly ICustomerService _customerService;

      public BookingService(IBookingRepository bookingRepository, IShowService showService, ICustomerService customerService)
      {
            _bookingRepository = bookingRepository;
            _showService = showService;
            _customerService = customerService;
      }

      public async Task<PagedResult<Booking>> GetAllBookings(BookingFilterParams filterParams)
      {
            var query = _bookingRepository.Query();
            if (!string.IsNullOrWhiteSpace(filterParams.CustomerName))
            {
                  query = query.Where(b => b.Customer.Name.Contains(filterParams.CustomerName, StringComparison.OrdinalIgnoreCase));
            }
            if ((filterParams.CustomerId).HasValue)
            {
                  query = query.Where(b => b.CustomerId.Equals(filterParams.CustomerId));
            }
            if ((filterParams.ShowId).HasValue)
            {
                  query = query.Where(b => b.ShowId.Equals(filterParams.ShowId));
            }
            if ((filterParams.Status).HasValue)
            {
                  query = query.Where(b => b.Status == filterParams.Status);
            }
            var totalCount = await query.CountAsync();
            query = query.Skip((filterParams.Page - 1) * filterParams.PageSize).Take(filterParams.PageSize);
            var bookings = await query.ToListAsync();

            return new PagedResult<Booking>
            {
                  Data = bookings,
                  Page = filterParams.Page,
                  PageSize = filterParams.PageSize,
                  TotalCount = totalCount
            };
      }

      public async Task<Booking> GetBookingById(int id)
      {
            var booking = await _bookingRepository.GetById(id);
            if (booking == null) throw new BookingNotFoundException(id);
            return booking;
      }
      public async Task<Booking> CreateBooking(Booking booking)
      {
            await _showService.GetShowById(booking.ShowId);
            await _customerService.GetCustomerById(booking.CustomerId);
            booking.Status = Enums.BookingStatus.Pending;
            var newBooking = await _bookingRepository.AddBooking(booking);

            return newBooking;
      }
      public async Task UpdateBooking(int id, BookingStatus status)
      {
            var current = await GetBookingById(id);
            if (status == BookingStatus.Confirmed)            {

                  if (current.Status == BookingStatus.Cancelled)
                  {
                        throw new InvalidBookingException("Cannot confirm a cancelled booking");
                  }

                  if (DateTime.Compare(current.Show.ShowTime, DateTime.Now) < 1)
                  {
                        throw new InvalidBookingException("Cannot confirm booking for past date");
                  }
            }
            if (status == BookingStatus.Cancelled)
            {
                  if (DateTime.Compare(current.Show.ShowTime, DateTime.Now) < 1)
                  {
                        throw new InvalidBookingException("Cannot cancel booking for past date");
                  } 
            }
            await _bookingRepository.UpdateBooking(id, status);
      }
      public async Task DeleteBooking(int id)
      {
            await GetBookingById(id);
            await _bookingRepository.DeleteBooking(id);
      }

}