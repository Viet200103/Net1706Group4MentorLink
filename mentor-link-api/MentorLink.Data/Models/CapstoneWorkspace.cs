using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MentorLink.Data.Models;

public partial class CapstoneWorkspace
{
    [Key]
    public int CapstoneWorkspaceId { get; set; }

    [Required]
    [MaxLength(255)]
    public string Name { get; set; }

    [MaxLength(50)]
    public string Status { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    [MaxLength(100)]
    public string WorkspaceCode { get; set; }
}
