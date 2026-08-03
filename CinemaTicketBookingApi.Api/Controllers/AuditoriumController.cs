using CinemaTicketBookingApi.Api.Dtos;
using CinemaTicketBookingApi.Api.Mapping;
using CinemaTicketBookingApi.Api.Models;
using CinemaTicketBookingApi.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CinemaTicketBookingApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class AuditoriumController : ControllerBase
{
      private readonly IAuditoriumService _auditoriumService;
      public AuditoriumController(IAuditoriumService auditoriumService)
      {
            _auditoriumService = auditoriumService;
      }

      [HttpGet]
      public async Task<ActionResult<PagedResult<AuditoriumDto>>> GetAll([FromQuery] PaginationParams paginationParams)
      {
            var result = await _auditoriumService.GetAllAuditoriums(paginationParams);
            var dto = AuditoriumMapper.ToDto(result);
            return Ok(dto);
      }
      [HttpGet("{id}")]
      public async Task<ActionResult<AuditoriumDto>> GetById(int id)
      {
            var auditorium = await _auditoriumService.GetAuditoriumById(id);
            var dto = AuditoriumMapper.ToDto(auditorium);
            return Ok(dto);
      }
      [HttpPost]
      public async Task<ActionResult<AuditoriumDto>> Create(CreateAuditoriumDto dto)
      {
            var auditorium = AuditoriumMapper.ToEntity(dto);
            await _auditoriumService.CreateAuditorium(auditorium);
            var responseDto = AuditoriumMapper.ToDto(auditorium);
            return CreatedAtAction(nameof(GetById), new { id = responseDto.Id }, responseDto);
      }
      [HttpPut("{id}")]
      public async Task<ActionResult> Update(int id, CreateAuditoriumDto dto)
      {
            var auditorium = AuditoriumMapper.ToEntity(dto);
            await _auditoriumService.UpdateAuditorium(id, auditorium);
            return NoContent();
      }
      [HttpDelete("{id}")]
      public async Task<ActionResult> Delete(int id)
      {
            await _auditoriumService.DeleteAuditorium(id);
            return NoContent();
      }
}