using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MentorLink.Data.Models;

public partial class News
{
    [Key]
    public int NewsId { get; set; }

    [Required]
    [MaxLength(255)]
    public string Title { get; set; }

    [Column(TypeName = "json")]
    public string Content { get; set; } // Store JSON as string

    [Required]
    public int Author { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime PublicDate { get; set; } = DateTime.UtcNow;

    [MaxLength(100)]
    public string Category { get; set; }

    public int Status { get; set; } = 0;
    public int UpdateStatus { get; set; } = 0;
}
