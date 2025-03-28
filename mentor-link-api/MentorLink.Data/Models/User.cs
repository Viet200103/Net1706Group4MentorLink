using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MentorLink.Data.Models;

[Table("User")]
public class User
{
    [Column("UserId")]
    [MaxLength(128)]
    public string UserId { get; set; }
    
    [Column("Email")]
    [MaxLength(255)]
    public string Email { get; set; }
    
    [Column("Password")]
    [MaxLength(128)]
    public string Password { get; set; }
    
    [Column("CreateAt")]
    [DataType("Timestamp")]
    public DateTime CreatedAt { get; set; }
    
    [Column("UpdateAt")]
    [DataType("Timestamp")]
    public DateTime UpdatedAt { get; set; }
}