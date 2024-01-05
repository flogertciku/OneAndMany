#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace OneAndMany.Models;
public class Comment
{
    [Key]
    public int CommentId  { get; set; }
    public int? PostId {get;set;}
    public int? UserId {get;set;}

    public string Content { get; set; } 

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public User? creatorOfComment {get;set;}
    public Post? postOfComment {get;set;}
}
                
