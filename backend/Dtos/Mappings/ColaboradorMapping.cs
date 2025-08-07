using AutoMapper;
using backend.Models;

namespace backend.Dtos.Mappings;

public class ColaboradorMapping : Profile
{
    public ColaboradorMapping()
    {
        CreateMap<Colaborador, ColaboradorDTO>();
        CreateMap<ColaboradorDTO, Colaborador>();
    }
}