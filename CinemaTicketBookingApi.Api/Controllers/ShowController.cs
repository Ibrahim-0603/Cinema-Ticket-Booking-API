using CinemaTicketBookingApi.Api.Dtos;
using CinemaTicketBookingApi.Api.Mapping;
using CinemaTicketBookingApi.Api.Models;
using CinemaTicketBookingApi.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketBookingApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShowsController : ControllerBase
{
      private readonly IShowService _showService;
      public ShowsController(IShowService showService)
      {
            _showService = showService;
      }

      [HttpGet]
      public async Task<ActionResult<PagedResult<ShowDto>>> GetAll([FromQuery] PaginationParams paginationParams)
      {
            var result = await _showService.GetAllShows(paginationParams);
            var dto = ShowMapper.ToDto(result);
            return Ok(dto);
      }

      [HttpGet("{id}")]
      public async Task<ActionResult<ShowDto>> GetById(int id)
      {
            var show = await _showService.GetShowById(id);
            var dto = ShowMapper.ToDto(show);
            return Ok(dto);
      }

      [HttpPost]
      public async Task<ActionResult<ShowDto>> Create(CreateShowDto dto)
      {
            var show = ShowMapper.ToEntity(dto);
            var created = await _showService.CreateShow(show);
            var responseDto = ShowMapper.ToDto(created);
            return CreatedAtAction(nameof(GetById), new { id = responseDto.Id }, responseDto);
      }

      [HttpPut("{id}")]
      public async Task<ActionResult> Update(int id, CreateShowDto dto)
      {
            var show = ShowMapper.ToEntity(dto);
            await _showService.UpdateShow(id, show);
            return NoContent();
      }

      [HttpDelete("{id}")]
      public async Task<ActionResult> Delete(int id)
      {
            await _showService.DeleteShow(id);
            return NoContent();
      }
}