using backend.Dtos;
using backend.Models;

namespace backend.Services;

public interface IColaboradorService
{
    Task<IEnumerable<Colaborador>> GetColaboradoresAsync();
    Task<Colaborador> CreateColaboradorAsync(ColaboradorDTO colaboradorDTO);
    Task<ColaboradorDTO> UpdateColaboradorAsync(int id, ColaboradorDTO colaboradorDTO);
    Task<ColaboradorDTO> DeleteColaboradorAsync(int id);
}