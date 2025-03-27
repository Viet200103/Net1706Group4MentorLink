using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MentorLink.Data.Models;

[Table("NewsCategory")]
public class NewsCategory
{
    [Key] public int CategoryId { get; set; }
    
    [Required] [MaxLength(255)] public string Name { get; set; }
}