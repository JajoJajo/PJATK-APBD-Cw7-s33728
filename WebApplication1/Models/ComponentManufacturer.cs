using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class ComponentManufacturer
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string Abbreviation { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(300)]
    public string FullName { get; set; } = string.Empty;
    
    public DateOnly FoundationDate { get; set; }
    
    public IEnumerable<Component> Components {get; set;} = [];
}