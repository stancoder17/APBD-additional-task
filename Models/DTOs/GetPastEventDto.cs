namespace WebAPI_Conferences.Models.DTOs;

public class GetPastEventDto
{
    public GetEventDto Event { get; set; } = null!;
    public List<GetSpeakerDto> Speakers { get; set; } = [];
}