using System.ComponentModel.DataAnnotations;

namespace WebAPI_Conferences.Models;

public class Event
{
    [Key]
    public int IdEvent { get; set; }
    
    [Required] [MaxLength(100)]
    public string Title { get; set; } = null!;
    
    [Required] [MaxLength(200)]
    public string Description { get; set; } = null!;
    
    [Required]
    public DateTime Date { get; set; }
    
    [Required]
    public int MaxPeople { get; set; }
    
    public virtual ICollection<ParticipantEvent> ParticipantRegistrations { get; set; } = null!;
    public virtual ICollection<SpeakerEvent> SpeakerRegistrations { get; set; } = null!;
}