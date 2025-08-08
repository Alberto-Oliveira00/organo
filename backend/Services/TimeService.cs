using AutoMapper;
using backend.Dtos;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services;

public class TimeService : ITimeService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public TimeService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<TimeDTO>> GetTimesAsync()
    {
        var times = await _context.Times.AsNoTracking().ToListAsync();

        var timesDto = _mapper.Map<IEnumerable<TimeDTO>>(times);
        return timesDto;
    }
    public async Task<TimeDTO> CreateTimeAsync(TimeDTO timeDTO)
    {
        var novoTime = _mapper.Map<Time>(timeDTO);

        _context.Times.Add(novoTime);
        await _context.SaveChangesAsync();

        var timeDto = _mapper.Map<TimeDTO>(novoTime);
        return timeDto;        
    }
    public async Task<TimeDTO> UpdateTimeAsync(int id, TimeDTO timeDTO)
    {
        var time = await _context.Times.FirstOrDefaultAsync(t => t.TimeID == id);
        if (time is null)
            return null;

        _mapper.Map(timeDTO, time);

        await _context.SaveChangesAsync();

        var timeDto = _mapper.Map<TimeDTO>(time);
        return timeDto;
    }
    public async Task<TimeDTO> DeleteTimeAsync(int id)
    {
        var time = await _context.Times.FirstOrDefaultAsync(t => t.TimeID == id);
        if (time is null)
            return null;

        _context.Remove(time);
        await _context.SaveChangesAsync();

        return _mapper.Map<TimeDTO>(time);
    }
}