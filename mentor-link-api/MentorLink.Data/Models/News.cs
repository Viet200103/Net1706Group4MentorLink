using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MentorLink.Data.Models;

[Table("News")]
public partial class News
{
    [Key] public int NewsId { get; set; }

    [Required] [MaxLength(255)] public string Title { get; set; }

    [Column(TypeName = "json")] public string Content { get; set; }

    [Required] public int Author { get; set; }

    [Column(TypeName = "timestamp")]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime PublicDate { get; set; } = DateTime.Now;

    [ForeignKey("NewsCategory")] public int CategoryId { get; set; }

    [Required] public int Status { get; set; } = 0;

    public virtual NewsCategory NewsCategory { get; set; }
}