using System.ComponentModel.DataAnnotations;

namespace MentorLink.Data.Models;

public class NewsCategory
{
    [Key] public int CategoryId { get; set; }
    
    [Required] [MaxLength(255)] public string Name { get; set; }
    
    public virtual ICollection<News> News { get; set; }
}