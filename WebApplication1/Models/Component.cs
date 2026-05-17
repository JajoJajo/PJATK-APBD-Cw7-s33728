using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Component
{
    [Key]
    [Column(TypeName = "char(10)")]
    public string Code {get; set;} = string.Empty;
    
    [Required]
    [MaxLength(300)]
    public string Name { get; set; } = string.Empty;
    
    public string? Description { get; set; }
    
    public int ComponentManufacturersId { get; set; }
    public ComponentManufacturer ComponentManufacturers { get; set; } = null!;
    
    public int ComponentTypesId { get; set; }
    public ComponentType ComponentTypes { get; set; } = null!;

    public IEnumerable<PCComponent> PCComponents { get; set; } = [];
}