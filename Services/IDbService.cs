using WebAPI_Conferences.Models.DTOs;

namespace WebAPI_Conferences.Services;

public interface IDbService
{
    public Task<GetEventDto> AddEventAsync(AddEventDto dto, CancellationToken cancellationToken);
}