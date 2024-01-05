#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace OneAndMany.Models;
public class User
{
    [Key]
    public int UserId { get; set; }
    [Required]
    public string Name { get; set; } 
    [Required]
    public string Description { get; set; }
    public List<Post>? Posts {get;set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
                
