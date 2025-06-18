namespace WebAPI_Conferences.Models.DTOs;

public class GetEventWithSpeakersDto
{
    public int IdEvent { get; set; }
    public IEnumerable<GetSpeakerDto> Speakers { get; set; } = [];
}