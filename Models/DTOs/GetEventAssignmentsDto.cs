namespace WebAPI_Conferences.Models.DTOs;

public class GetEventAssignmentsDto
{
    public int IdEvent { get; set; }
    public IEnumerable<GetSpeakerDto> Speakers { get; set; } = [];
}