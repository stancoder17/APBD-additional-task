using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_Conferences.Models;

[Table("Participant_Event")]
[PrimaryKey(nameof(IdEvent), nameof(IdParticipant))]
public class ParticipantEvent
{
    public int IdEvent { get; set; }
    public int IdParticipant { get; set; }

    public DateTime RegistrationDate { get; set; }

    [ForeignKey(nameof(IdEvent))]
    public virtual Event Event { get; set; } = null!;

    [ForeignKey(nameof(IdParticipant))] 
    public virtual Participant Participant { get; set; } = null!;
}