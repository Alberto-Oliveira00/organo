using System.ComponentModel.DataAnnotations;
using backend.Models;

namespace backend.Dtos;

public class ColaboradorDTO
{
    public int ColaboradorID { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(20, ErrorMessage = "O nome deve ter entre 5 e 20 caracteres", MinimumLength = 5)]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "Cargo é obrigatório")]
    public string? Cargo { get; set; }
    public string? Imagem { get; set; }
    public int TimeID { get; set; }
}