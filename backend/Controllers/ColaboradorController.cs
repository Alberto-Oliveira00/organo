using AutoMapper;
using backend.Dtos;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IColaboradorService _service;
        private readonly IMapper _mapper;

        public ColaboradorController(AppDbContext context, IColaboradorService service, IMapper mapper)
        {
            _context = context;
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ColaboradorDTO>> GetColaboradorAsync()
        {
            var colaboradores = await _service.GetColaboradoresAsync();
            return _mapper.Map<IEnumerable<ColaboradorDTO>>(colaboradores);
        }

        [HttpPost]
        public async Task<ActionResult<ColaboradorDTO>> PostColaborador(ColaboradorDTO colaboradorDTO)
        {
            if (colaboradorDTO is null)
                return BadRequest("Colaborador inválido...");

            var colaboradorCriado = await _service.CreateColaboradorAsync(colaboradorDTO);

            var colaboradorCriadoDTO = _mapper.Map<ColaboradorDTO>(colaboradorCriado);

            return CreatedAtAction(nameof(PostColaborador), new { id = colaboradorCriado.ColaboradorID }, colaboradorCriadoDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ColaboradorDTO>> Put(int id, ColaboradorDTO colaboradorDTO)
        {
            if (colaboradorDTO is null)
            return StatusCode(500, $"Colaborador com id: {id} não existe.");

            var colaboradorEditado = await _service.UpdateColaboradorAsync(id, colaboradorDTO);

            var colaboradorEditadoDTO = _mapper.Map<ColaboradorDTO>(colaboradorEditado);

            return Ok(colaboradorEditadoDTO);
        }
    }
}
