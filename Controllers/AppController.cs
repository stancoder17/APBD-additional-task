using Microsoft.AspNetCore.Mvc;
using WebAPI_Conferences.Exceptions;
using WebAPI_Conferences.Models.DTOs;
using WebAPI_Conferences.Services;

namespace WebAPI_Conferences.Controllers;

[ApiController]
[Route("api")]
public class AppController(IDbService service) : ControllerBase
{
    [HttpPost("events")]
    public async Task<IActionResult> AddEvent([FromBody] AddEventDto dto, CancellationToken cancellationToken)
    {
        try
        {
            var newEvent = await service.AddEventAsync(dto, cancellationToken);
            return Created(string.Empty, newEvent);
        }
        catch (BadRequestException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("events/{id:int}/speakers")]
    public async Task<IActionResult> AddSpeakersToEvent([FromRoute] int id, [FromBody] List<SpeakerEventDto> speakerDtos, CancellationToken cancellationToken)
    {
        try
        {
            return Ok(await service.AddSpeakersToEventAsync(id, speakerDtos, cancellationToken));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (BadRequestException e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost("events/{idEvent:int}/participants/{idParticipant:int}")]
    public async Task<IActionResult> AddParticipantToEvent([FromRoute] int idEvent, [FromRoute] int idParticipant, CancellationToken cancellationToken)
    {
        try
        {
            await service.AddParticipantToEventAsync(idEvent, idParticipant, cancellationToken);
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (BadRequestException e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpDelete("events/{idEvent:int}/participants/{idParticipant:int}")]
    public async Task<IActionResult> RemoveParticipantFromEvent([FromRoute] int idEvent, [FromRoute] int idParticipant, CancellationToken cancellationToken)
    {
        try
        {
            await service.RemoveParticipantFromEventAsync(idEvent, idParticipant, cancellationToken);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (BadRequestException e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("events/future")]
    public async Task<IActionResult> GetFutureEvents(CancellationToken cancellationToken)
    {
        return Ok(await service.GetFutureEventsAsync(cancellationToken));
    }
    
    [HttpGet("participants/{idParticipant:int}/events/past")]
    public async Task<IActionResult> GetPastEvents([FromRoute] int idParticipant, CancellationToken cancellationToken)
    {
        try
        {
            return Ok(await service.GetPastEventsAsync(idParticipant, cancellationToken));
        } 
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}