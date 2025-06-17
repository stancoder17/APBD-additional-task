using Microsoft.AspNetCore.Mvc;
using WebAPI_Conferences.Models.DTOs;
using WebAPI_Conferences.Services;

namespace WebAPI_Conferences.Controllers;

[ApiController]
[Route("api")]
public class AppController(IDbService service) : ControllerBase
{
    [HttpPost("events")]
    public async Task<IActionResult> AddEvent(AddEventDto dto, CancellationToken cancellationToken)
    {
        var newEvent = await service.AddEventAsync(dto, cancellationToken);
        return Created(string.Empty, newEvent);
    }
}