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
        private readonly IColaboradorService _service;
        private readonly IMapper _mapper;

        public ColaboradorController(IColaboradorService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ColaboradorDTO>>> GetColaboradorAsync()
        {
            var colaboradores = await _service.GetColaboradoresAsync();
            if (colaboradores == null || !colaboradores.Any())
                return NotFound("Nenhum colaborador encontrado.");

            return Ok(colaboradores);
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

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ColaboradorDTO>> DeleteColaborador(int id)
        {
            try
            {
                var colaborador = await _service.DeleteColaboradorAsync(id);

                return Ok($"Colaborador de id: {id} deletado com sucesso");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao excluir colaborador.");
            }
        }
    }
}
