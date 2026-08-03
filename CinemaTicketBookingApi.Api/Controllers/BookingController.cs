using CinemaTicketBookingApi.Api.Dtos;
using CinemaTicketBookingApi.Api.Enums;
using CinemaTicketBookingApi.Api.Mapping;
using CinemaTicketBookingApi.Api.Models;
using CinemaTicketBookingApi.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketBookingApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class BookingController : ControllerBase
{
      private readonly IBookingService _bookingService;
      public BookingController(IBookingService bookingService)
      {
            _bookingService = bookingService;
      }

      [HttpGet]
      public async Task<ActionResult<PagedResult<BookingDto>>> GetAll([FromQuery] BookingFilterParams filterParams)
      {
            var result = await _bookingService.GetAllBookings(filterParams);
            var dto = BookingMapper.ToDto(result);
            return Ok(dto);
      }
      [HttpGet("{id}")]
      public async Task<ActionResult<BookingDto>> GetById(int id)
      {
            var booking = await _bookingService.GetBookingById(id);
            var dto = BookingMapper.ToDto(booking);
            return Ok(dto);
      }
      [HttpPost]
      public async Task<ActionResult<BookingDto>> Create(CreateBookingDto dto)
      {
            var booking = BookingMapper.ToEntity(dto);
            await _bookingService.CreateBooking(booking);
            var responseDto = BookingMapper.ToDto(booking);
            return CreatedAtAction(nameof(GetById), new { id = responseDto.Id }, responseDto);
      }
      [HttpPatch("{id}/confirm")]
      public async Task<ActionResult> Confirm(int id)
      {
            await _bookingService.UpdateBooking(id, BookingStatus.Confirmed);
            return NoContent();
      }

      [HttpPatch("{id}/cancel")]
      public async Task<ActionResult> Cancel(int id)
      {
            await _bookingService.UpdateBooking(id, BookingStatus.Cancelled);
            return NoContent();
      }
      [HttpDelete("{id}")]
      public async Task<ActionResult> Delete(int id)
      {
            await _bookingService.DeleteBooking(id);
            return NoContent();
      }
}