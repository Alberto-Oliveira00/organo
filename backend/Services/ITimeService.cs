using backend.Dtos;
using backend.Models;

namespace backend.Services;

public interface ITimeService
{
    Task<IEnumerable<TimeDTO>> GetTimesAsync();
    Task<TimeDTO> UpdateTimeAsync(int id, TimeDTO timeDTO);
    Task<TimeDTO> CreateTimeAsync(TimeDTO timeDTO);
    Task<TimeDTO> DeleteTimeAsync(int id);
}