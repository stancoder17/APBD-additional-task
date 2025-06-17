using System.ComponentModel.DataAnnotations;

namespace WebAPI_Conferences.Models;

public class Speaker
{
    [Key]
    public int IdSpeaker { get; set; }

    [Required] [MaxLength(50)]
    public string FirstName { get; set; } = null!;
    
    [Required] [MaxLength(100)]
    public string LastName { get; set; } = null!;
    
    [MaxLength(100)]
    public string? Email { get; set; }

    public virtual ICollection<SpeakerEvent> EventRegistrations { get; set; } = null!;
}