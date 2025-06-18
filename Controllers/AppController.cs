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

    [HttpPost("events/{id:int}")]
    public async Task<IActionResult> AddSpeakersToEvent([FromRoute] int id, [FromBody] IEnumerable<SpeakerEventDto> speakerDtos, CancellationToken cancellationToken)
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
}