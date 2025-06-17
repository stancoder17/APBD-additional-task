using WebAPI_Conferences.DAT;
using WebAPI_Conferences.Exceptions;
using WebAPI_Conferences.Models;
using WebAPI_Conferences.Models.DTOs;

namespace WebAPI_Conferences.Services;

public class DbService(AppDbContext context) : IDbService
{
    public async Task<GetEventDto> AddEventAsync(AddEventDto dto, CancellationToken cancellationToken)
    {
        // Data validation
        if (dto.Date < DateTime.Now)
            throw new BadRequestException("New event's date cannot be in the past.");
        if (dto.MaxPeople < 0)
            throw new BadRequestException("Number of max people cannot be negative.");
        if (dto.Title.Trim().Length == 0)
            throw new BadRequestException("Title cannot be empty.");

        var newEvent = new Event
        {
            Title = dto.Title,
            Description = dto.Description,
            Date = dto.Date,
            MaxPeople = dto.MaxPeople,
        };
        context.Events.Add(newEvent);
        
        await context.SaveChangesAsync(cancellationToken);

        return new GetEventDto
        {
            IdEvent = newEvent.IdEvent,
            Title = newEvent.Title,
            Description = newEvent.Description,
            Date = newEvent.Date,
            MaxPeople = newEvent.MaxPeople
        };
    }
}