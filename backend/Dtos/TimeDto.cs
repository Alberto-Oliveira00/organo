using System.ComponentModel.DataAnnotations;
using backend.Models;

namespace backend.Dtos;

public class TimeDTO
{
    [Key]
    public int TimeID { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(80)]
    public string? NomeTime { get; set; }
    
    [StringLength(20)]
    public string? CorPadrao { get; set; }
    public ICollection<Colaborador>? Colaboradores { get; set; }
}