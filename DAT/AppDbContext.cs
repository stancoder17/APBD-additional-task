using Microsoft.EntityFrameworkCore;
using WebAPI_Conferences.Models;

namespace WebAPI_Conferences.DAT;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Participant> Participants { get; set; }
    public DbSet<Speaker> Speakers { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<SpeakerEvent> SpeakerEvents { get; set; }
    public DbSet<ParticipantEvent> ParticipantEvents { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Participant>().HasData(
        new Participant { IdParticipant = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" },
        new Participant { IdParticipant = 2, FirstName = "Anna", LastName = "Kowalska", Email = "anna.k@example.com" },
        new Participant { IdParticipant = 3, FirstName = "Mike", LastName = "Johnson", Email = "mike.j@example.com" },
        new Participant { IdParticipant = 4, FirstName = "Sara", LastName = "Smith", Email = "sara.s@example.com" },
        new Participant { IdParticipant = 5, FirstName = "Tom", LastName = "Clark", Email = "tom.c@example.com" },
        new Participant { IdParticipant = 6, FirstName = "Ewa", LastName = "Nowak", Email = "ewa.n@example.com" },
        new Participant { IdParticipant = 7, FirstName = "Liam", LastName = "Brown", Email = "liam.b@example.com" },
        new Participant { IdParticipant = 8, FirstName = "Olga", LastName = "Zielińska", Email = "olga.z@example.com" },
        new Participant { IdParticipant = 9, FirstName = "Peter", LastName = "Adams", Email = "peter.a@example.com" },
        new Participant { IdParticipant = 10, FirstName = "Marta", LastName = "Wiśniewska", Email = "marta.w@example.com" }
    );

    modelBuilder.Entity<Speaker>().HasData(
        new Speaker { IdSpeaker = 1, FirstName = "Alice", LastName = "Johnson", Email = "alice@example.com" },
        new Speaker { IdSpeaker = 2, FirstName = "Bob", LastName = "Smith", Email = "bob@example.com" },
        new Speaker { IdSpeaker = 3, FirstName = "Carol", LastName = "Davis", Email = "carol@example.com" },
        new Speaker { IdSpeaker = 4, FirstName = "David", LastName = "Lee", Email = "david@example.com" }
    );

    modelBuilder.Entity<Event>().HasData(
        new Event
        {
            IdEvent = 1,
            Title = "Tech Conference 2025",
            Description = "A conference about the latest tech.",
            Date = new DateTime(2025, 10, 10),
            MaxPeople = 100
        },
        new Event
        {
            IdEvent = 2,
            Title = "AI Workshop",
            Description = "Hands-on workshop on AI.",
            Date = new DateTime(2025, 11, 15),
            MaxPeople = 50
        }
    );

    modelBuilder.Entity<ParticipantEvent>().HasData(
        new { IdEvent = 1, IdParticipant = 1, RegistrationDate = new DateTime(2025, 6, 1) },
        new { IdEvent = 1, IdParticipant = 2, RegistrationDate = new DateTime(2025, 6, 2) },
        new { IdEvent = 1, IdParticipant = 3, RegistrationDate = new DateTime(2025, 6, 3) },
        new { IdEvent = 2, IdParticipant = 4, RegistrationDate = new DateTime(2025, 6, 5) },
        new { IdEvent = 2, IdParticipant = 5, RegistrationDate = new DateTime(2025, 6, 6) }
    );

    modelBuilder.Entity<SpeakerEvent>().HasData(
        new { IdEvent = 1, IdSpeaker = 1, SpeakingTime = 45 },
        new { IdEvent = 1, IdSpeaker = 2, SpeakingTime = 30 },
        new { IdEvent = 2, IdSpeaker = 3, SpeakingTime = 60 },
        new { IdEvent = 2, IdSpeaker = 4, SpeakingTime = 50 }
    );
}
}