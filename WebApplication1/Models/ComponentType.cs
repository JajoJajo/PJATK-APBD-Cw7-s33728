using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class ComponentType
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string Abbreviation { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(150)]
    public string Name { get; set; } = string.Empty;
}