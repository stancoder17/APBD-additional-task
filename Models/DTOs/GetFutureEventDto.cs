namespace WebAPI_Conferences.Models.DTOs;

public class GetFutureEventDto
{
    public GetEventDto EventDto { get; set; } = null!;
    public int ParticipantsCount { get; set; }
    public int AvailableSpots { get; set; }
    public List<GetSpeakerDto> Speakers { get; set; } = [];
}