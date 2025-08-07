using AutoMapper;
using backend.Dtos;
using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TimeController : ControllerBase
{
    private readonly ITimeService _service;
    private readonly IMapper _mapper;

    public TimeController(ITimeService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TimeDTO>>> GetAsync()
    {
        var times = await _service.GetTimesAsync();
        if (times is null)
            return NotFound("Nenhum time encontrado.");

        var timesDto = _mapper.Map<IEnumerable<TimeDTO>>(times);

        return Ok(timesDto);
    }
}
