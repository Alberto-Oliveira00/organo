using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
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
    [JsonIgnore]
    public ICollection<Colaborador>? Colaboradores { get; set; }
}