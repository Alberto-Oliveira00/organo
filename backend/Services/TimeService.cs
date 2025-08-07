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
    public Task<TimeDTO> CreateTimeAsync(TimeDTO timeDTO)
    {
        throw new NotImplementedException();
    }
    public Task<TimeDTO> UpdateTimeAsync(int id, TimeDTO timeDTO)
    {
        throw new NotImplementedException();
    }
    public Task<TimeDTO> DeleteTimeAsync(int id)
    {
        throw new NotImplementedException();
    }
}