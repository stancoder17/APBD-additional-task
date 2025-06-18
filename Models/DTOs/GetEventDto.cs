namespace WebAPI_Conferences.Models.DTOs;

public class GetEventDto
{
    public int IdEvent { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime Date { get; set; }
}