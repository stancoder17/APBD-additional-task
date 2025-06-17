using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_Conferences.Models;

[Table("Speaker_Event")]
[PrimaryKey(nameof(IdEvent), nameof(IdSpeaker))]
public class SpeakerEvent
{
    public int IdEvent { get; set; }
    public int IdSpeaker { get; set; }

    public int SpeakingTime { get; set; } // in minutes

    [ForeignKey(nameof(IdEvent))]
    public virtual Event Event { get; set; } = null!;

    [ForeignKey(nameof(IdSpeaker))] 
    public virtual Speaker Speaker { get; set; } = null!;
}