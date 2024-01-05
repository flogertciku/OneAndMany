#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace OneAndMany.Models;
public class Post
{
    [Key]
    public int PostId { get; set; }
    [Required]
    public string Content { get; set; } 
    public int? UserId {get;set;}
    public User? Creator {get;set;}
    public List<Comment>? komentet {get;set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
                
