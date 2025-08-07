using AutoMapper;
using backend.Dtos;
using backend.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace backend.Services;

public class ColaboradorService : IColaboradorService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ColaboradorService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Colaborador>> GetColaboradoresAsync()
    {
        var colaboradores = await _context.Colaboradores.Include(c => c.Time).AsNoTracking().ToListAsync();

        if (colaboradores is null)
            throw new ApplicationException("Colaboradores não encontrados");

        return colaboradores;
    }

    public async Task<Colaborador> CreateColaboradorAsync(ColaboradorDTO colaboradorDTO)
    {
        var timeExiste = await _context.Times.AnyAsync(t => t.TimeID == colaboradorDTO.TimeID);
        if (!timeExiste)
        throw new ArgumentException($"Time com ID {colaboradorDTO.TimeID} não existe.");

        var colaborador = _mapper.Map<Colaborador>(colaboradorDTO);

        _context.Colaboradores.Add(colaborador);
        await _context.SaveChangesAsync();

        return colaborador;
    }

    public async Task<ColaboradorDTO> UpdateColaboradorAsync(int id, ColaboradorDTO colaboradorDTO)
    {
        var colaborador = await _context.Colaboradores.FirstOrDefaultAsync(c => c.ColaboradorID == id);

        if (colaborador is null)
            throw new ArgumentException($"Colaborador com id: {id} não existe.");

        var time = await _context.Times.FirstOrDefaultAsync(t => t.TimeID == colaboradorDTO.TimeID);
        if (time is null)
            throw new ArgumentException($"Time com ID {colaboradorDTO.TimeID} não existe.");

        _mapper.Map(colaboradorDTO, colaborador);

        await _context.SaveChangesAsync();

        var colaboradorNovoDTO = _mapper.Map<ColaboradorDTO>(colaborador);

        return colaboradorNovoDTO;
    }

    public async Task<ColaboradorDTO> DeleteColaboradorAsync(int id)
    {
        var colaborador = await _context.Colaboradores.FirstOrDefaultAsync(c => c.ColaboradorID == id);
        if (colaborador is null)
            throw new ArgumentException($"Time com {id} não existe.");

        _context.Colaboradores.Remove(colaborador);

        await _context.SaveChangesAsync();

        return _mapper.Map<ColaboradorDTO>(colaborador);
    }

}