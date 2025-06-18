using WebAPI_Conferences.Models.DTOs;

namespace WebAPI_Conferences.Services;

public interface IDbService
{
    public Task<GetEventDto> AddEventAsync(AddEventDto dto, CancellationToken cancellationToken);
    public Task<GetEventWithSpeakersDto> AddSpeakersToEventAsync(int idEvent, List<SpeakerEventDto> speakerDtos, CancellationToken cancellationToken);
    public Task AddParticipantToEventAsync(int idEvent, int idParticipant, CancellationToken cancellationToken);
}