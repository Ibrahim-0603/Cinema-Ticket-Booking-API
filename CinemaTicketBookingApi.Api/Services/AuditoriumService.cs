using CinemaTicketBookingApi.Api.Exceptions;
using CinemaTicketBookingApi.Api.Models;
using CinemaTicketBookingApi.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CinemaTicketBookingApi.Api.Services;

public class AuditoriumService : IAuditoriumService
{
      private readonly IAuditoriumRepository _auditoriumRepository;
      public AuditoriumService(IAuditoriumRepository auditoriumRepository)
      {
            _auditoriumRepository = auditoriumRepository;
      }
      public async Task<PagedResult<Auditorium>> GetAllAuditoriums(PaginationParams paginationParams)
      {
            var query = _auditoriumRepository.Query();

            var totalCount = await query.CountAsync();
            query = query.Skip((paginationParams.Page - 1) * paginationParams.PageSize).Take(paginationParams.PageSize);
            var auditoriums = await query.ToListAsync();

            return new PagedResult<Auditorium>
            {
                  Data = auditoriums,
                  Page = paginationParams.Page,
                  PageSize = paginationParams.PageSize,
                  TotalCount = totalCount
            };
      }
      public async Task<Auditorium> GetAuditoriumById(int id)
      {
            var auditorium = await _auditoriumRepository.GetById(id);
            if (auditorium == null) throw new AuditoriumNotFoundException(id);
            return auditorium;
      }
      public async Task<Auditorium> CreateAuditorium(Auditorium auditorium)
      {
            var newAuditorium = await _auditoriumRepository.AddAuditorium(auditorium);
            return newAuditorium;
      }
      public async Task UpdateAuditorium(int id, Auditorium auditorium)
      {
            await GetAuditoriumById(id);
            await _auditoriumRepository.UpdateAuditorium(id, auditorium);
      }

      public async Task DeleteAuditorium(int id)
      {
            
            var auditorium = await GetAuditoriumById(id);
            if (auditorium.Shows.Any())
            {
                  throw new InvalidOperationException($"Auditorium with ID {id} cannot be deleted because it has active shows");
            }
            await _auditoriumRepository.DeleteAuditorium(id);

      }
}