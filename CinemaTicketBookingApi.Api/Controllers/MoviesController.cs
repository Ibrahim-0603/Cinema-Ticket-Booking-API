using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using CinemaTicketBookingApi.Api.Services;
using CinemaTicketBookingApi.Api.Dtos;
using CinemaTicketBookingApi.Api.Mapping;
using CinemaTicketBookingApi.Api.Models;
using System.Runtime.CompilerServices;
namespace CinemaTicketBookingApi.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]

public class MoviesController : ControllerBase
{
      private readonly IMovieService _movieService;
      public MoviesController(IMovieService movieService)
      {
            _movieService = movieService;
      }

      [HttpGet]
      [MapToApiVersion("1.0")]
      public async Task<ActionResult<PagedResult<MovieDtoV1>>> GetAllV1([FromQuery] MovieFilterParams filterParams)
      {
      var result = await _movieService.GetAllMovies(filterParams);
      var dtoResult = MovieMapper.ToDtoV1(result);
      return Ok(dtoResult);
      }
      
      [HttpGet]
      [MapToApiVersion("2.0")]
      public async Task<ActionResult<PagedResult<MovieDtoV2>>> GetAllV2([FromQuery] MovieFilterParams filterParams)
      {
      var result = await _movieService.GetAllMovies(filterParams);
      var dtoResult = MovieMapper.ToDtoV2(result);
      return Ok(dtoResult);
      }


      [HttpGet("{id}")]
      [MapToApiVersion("1.0")]
      public async Task<ActionResult<MovieDtoV1>> GetByIdV1(int id)
      {
            var movie = await _movieService.GetMovieById(id);
            var dto = MovieMapper.ToDtoV1(movie);
            return Ok(dto);
      }
      [HttpGet("{id}")]
      [MapToApiVersion("2.0")]
      public async Task<ActionResult<MovieDtoV2>> GetByIdV2(int id)
      {
            var movie = await _movieService.GetMovieById(id);
            var dto = MovieMapper.ToDtoV2(movie);
            return Ok(dto);
      }

      [HttpPost]
      public async Task<ActionResult<MovieDtoV2>> Create(CreateMovieDto dto)
      {
      var movie = MovieMapper.ToEntity(dto);
      var created = await _movieService.CreateMovie(movie);
      var responseDto = MovieMapper.ToDtoV2(created);
      return CreatedAtAction(nameof(GetByIdV2), new { id = responseDto.Id }, responseDto);
      }

      [HttpPut("{id}")]
      public async Task<ActionResult> Update(int id, CreateMovieDto dto)
      {
            var movie = MovieMapper.ToEntity(dto);
            await _movieService.UpdateMovie(id, movie);
            return NoContent();
      }

      [HttpDelete("{id}")]
      public async Task<ActionResult> Delete(int id)
      {
            await _movieService.DeleteMovie(id);
            return NoContent();
      }



}