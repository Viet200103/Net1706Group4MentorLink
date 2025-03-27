using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MentorLink.Data.Models;

public partial class TaskBoard
{
    [Key]
    public int TaskBoardId { get; set; }

    [Required]
    [MaxLength(255)]
    public string Title { get; set; }

    public string Description { get; set; }

    [MaxLength(50)]
    public string Status { get; set; }

    [ForeignKey("CapstoneWorkspace")]
    public int? CapstoneWorkspaceId { get; set; }
    public CapstoneWorkspace CapstoneWorkspace { get; set; }
}
