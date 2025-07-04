﻿using Microsoft.EntityFrameworkCore;
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
            throw new BadRequestException("Title must contain at least one non-whitespace character.");

        // Create new Event
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
        };
    }

    public async Task<GetEventWithSpeakersDto> AddSpeakersToEventAsync(int idEvent, List<SpeakerEventDto> speakerDtos, CancellationToken cancellationToken)
    {
        // Check if Event exists
        if (!await context.Events.AnyAsync(e => e.IdEvent == idEvent, cancellationToken))
            throw new NotFoundException($"Event with id {idEvent} not found.");
        
        // Check if any Speaker was provided
        if (speakerDtos.Count == 0)
            throw new BadRequestException("No speakers provided.");
        
        var eventDate = await context.Events
            .Where(e => e.IdEvent == idEvent)
            .Select(e => e.Date)
            .FirstOrDefaultAsync(cancellationToken);

        var addedSpeakers = new List<GetSpeakerDto>(); // to include in DTO for return
        foreach (var speakerDto in speakerDtos)
        {
            // Get Speaker
            var speaker = await context.Speakers
                .Include(s => s.EventRegistrations)
                .ThenInclude(se => se.Event)
                .FirstOrDefaultAsync(s => s.IdSpeaker == speakerDto.IdSpeaker, cancellationToken);
            
            // Check if Speaker exists
            if (speaker == null)
                throw new NotFoundException($"Speaker with id {speakerDto.IdSpeaker} not found.");
            
            if (await context.SpeakerEvents.AnyAsync(se => se.IdSpeaker == speakerDto.IdSpeaker && se.IdEvent == idEvent, cancellationToken))
                throw new BadRequestException($"Speaker with id {speakerDto.IdSpeaker} is already registered on event with id {idEvent}.");
            
            // Check if Speaker doesn't have any other Event at the same time
            if (speaker.EventRegistrations.Count != 0)
            {
                if (speaker.EventRegistrations.Any(speakerEvent => speakerEvent.Event.Date.Date == eventDate.Date))
                    throw new BadRequestException($"Speaker with id {speakerDto.IdSpeaker} already has an event on date: {eventDate.Date.ToShortDateString()}.");
            }

            // Validate speaking time
            if (speakerDto.SpeakingTime < 0)
                throw new BadRequestException("Speaking time value cannot be negative.");
            
            // Add Speaker
            await context.SpeakerEvents.AddAsync(new SpeakerEvent
            {
                IdEvent = idEvent,
                IdSpeaker = speakerDto.IdSpeaker,
                SpeakingTime = speakerDto.SpeakingTime
            }, cancellationToken);
            
            addedSpeakers.Add(new GetSpeakerDto
            {
                LastName = speaker.LastName
            });
        }
        await context.SaveChangesAsync(cancellationToken);
        
        return new GetEventWithSpeakersDto
        {
            IdEvent = idEvent,
            Speakers = addedSpeakers
        };
    }

    public async Task AddParticipantToEventAsync(int idEvent, int idParticipant, CancellationToken cancellationToken)
    {
        var eventEntity = await context.Events
            .Select(e => new { e.IdEvent, e.Date, e.MaxPeople })
            .FirstOrDefaultAsync(e => e.IdEvent == idEvent ,cancellationToken);
        
        // Check if Event exists
        if (eventEntity == null)
            throw new NotFoundException($"Event with id {idEvent} not found.");
        
        // Check if Event is in the past
        if (eventEntity.Date < DateTime.Now)
            throw new BadRequestException($"Event with id {idEvent} has already started/taken place.");

        // Check if Participant exists
        if (!await context.Participants.AnyAsync(p => p.IdParticipant == idParticipant, cancellationToken))
            throw new NotFoundException($"Participant with id {idParticipant} not found.");
        
        // Check if Participant is already registered on this Event
        if (await context.ParticipantEvents.AnyAsync(pe => pe.IdEvent == idEvent && pe.IdParticipant == idParticipant, cancellationToken))
            throw new BadRequestException($"Participant with id {idParticipant} is already registered on event with id {idEvent}.");
        
        // Check if MaxPeople limit won't be exceeded
        var participantsCount = await context.ParticipantEvents.CountAsync(pe => pe.IdEvent == idEvent, cancellationToken);
        var maxPeople = eventEntity.MaxPeople;
        if (participantsCount == maxPeople)
            throw new BadRequestException($"Event with id {idEvent} is full.");
        
        // Add Participant
        await context.ParticipantEvents.AddAsync(new ParticipantEvent
        {
            IdEvent = idEvent,
            IdParticipant = idParticipant,
            RegistrationDate = DateTime.Now
        }, cancellationToken);
        
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveParticipantFromEventAsync(int idEvent, int idParticipant, CancellationToken cancellationToken)
    {
        var eventEntity = await context.Events
            .Select(e => new { e.IdEvent, e.Date })
            .FirstOrDefaultAsync(e => e.IdEvent == idEvent ,cancellationToken);
        
        // Check if Event exists
        if (eventEntity == null)
            throw new NotFoundException($"Event with id {idEvent} not found.");

        // Check if Participant exists
        if (!await context.Participants.AnyAsync(p => p.IdParticipant == idParticipant, cancellationToken))
            throw new NotFoundException($"Participant with id {idParticipant} not found.");
        
        // Check if Participant is registered on this Event
        if (!await context.ParticipantEvents.AnyAsync(pe => pe.IdEvent == idEvent && pe.IdParticipant == idParticipant, cancellationToken))
            throw new BadRequestException($"Participant with id {idParticipant} is not registered on event with id {idEvent}.");
        
        var dateDifference = DateTime.Now - eventEntity.Date;
        
        // Check if Event is in the past
        if (dateDifference.TotalHours > 0)
            throw new BadRequestException($"Event with id {idEvent} has already started/taken place.");

        // Check the 24 hours thing
        if (dateDifference.TotalHours > -24)
            throw new BadRequestException("A participant cannot be removed from an event less than 24 hours before it starts.");
        
        // Delete record
        await context.ParticipantEvents
            .Where(pe => pe.IdEvent == idEvent && pe.IdParticipant == idParticipant)
            .ExecuteDeleteAsync(cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<GetFutureEventDto>> GetFutureEventsAsync(CancellationToken cancellationToken)
    {
        return await context.Events
            .Where(e => e.Date > DateTime.Now)
            .Select(e => new
            {
                Event = e,
                ParticipantsCount = context.ParticipantEvents.Count(pe => pe.IdEvent == e.IdEvent)
            })
            .Select(e => new GetFutureEventDto
            {
                Event = new GetEventDto
                {
                    IdEvent = e.Event.IdEvent,
                    Title = e.Event.Title,
                    Description = e.Event.Description,
                    Date = e.Event.Date
                },
                ParticipantsCount = e.ParticipantsCount,
                AvailableSpots = e.Event.MaxPeople - e.ParticipantsCount,
                Speakers = e.Event.SpeakerRegistrations.Select(se => new GetSpeakerDto
                {
                    LastName = se.Speaker.LastName
                }).ToList()
            })
            .ToListAsync(cancellationToken);
    }


    public async Task<List<GetPastEventDto>> GetPastEventsAsync(int idParticipant, CancellationToken cancellationToken)
    {
        // Check if Participant exists
        if (!await context.Participants.AnyAsync(p => p.IdParticipant == idParticipant, cancellationToken))
            throw new NotFoundException($"Participant with id {idParticipant} not found.");
        
        // Return
        return await context.Events.
            Where(e => e.ParticipantRegistrations.Any(pe => pe.IdEvent == e.IdEvent && pe.IdParticipant == idParticipant)
                       && e.Date < DateTime.Now)
            .Select(e => new GetPastEventDto
            {
                Event = new GetEventDto
                {
                    IdEvent = e.IdEvent,
                    Title = e.Title,
                    Description = e.Description,
                    Date = e.Date
                },
                Speakers = e.SpeakerRegistrations.Select(se => new GetSpeakerDto
                {
                    LastName = se.Speaker.LastName
                }).ToList()
            }).ToListAsync(cancellationToken);
    }
}