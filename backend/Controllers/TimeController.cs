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

    [HttpPost]
    public async Task<ActionResult<TimeDTO>> PostAsync(TimeDTO timeDTO)
    {
        var time = await _service.CreateTimeAsync(timeDTO);

        var timeDto = _mapper.Map<TimeDTO>(time);

        return Ok(timeDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<TimeDTO>> PutAsync(int id, TimeDTO timeDTO)
    {
        if (id != timeDTO.TimeID)
        return BadRequest("ID do time na URL difere do corpo da requisição.");

        var time = await _service.UpdateTimeAsync(id, timeDTO);
        
        if (time is null)
            return BadRequest($"Time de id: {id} não encontrado");

        return Ok(time);
    }
}
