using AutoMapper;
using backend.Models;

namespace backend.Dtos.Mappings;

public class TimeMapping : Profile
{
    public TimeMapping()
    {
        CreateMap<Time, TimeDTO>();
        CreateMap<TimeDTO, Time>();
    }
}