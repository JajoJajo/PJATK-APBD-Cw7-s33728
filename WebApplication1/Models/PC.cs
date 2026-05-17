using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class PC
{
    public int Id { get; set; }

    [Required] 
    [MaxLength(50)] 
    public string Name { get; set; } = string.Empty;
    
    public float Weight { get; set; }
    
    public int Warranty { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public int Stock { get; set; }

    public IEnumerable<PCComponent> PCComponents { get; set; } = [];
}