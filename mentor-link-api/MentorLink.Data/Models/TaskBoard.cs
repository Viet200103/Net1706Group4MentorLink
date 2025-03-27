﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MentorLink.Data.Models;

[Table("TaskBoard")]
public partial class TaskBoard
{
    [Key] public int TaskBoardId { get; set; }

    [Required] [MaxLength(255)] public string Title { get; set; }

    [Column(TypeName = "TEXT")] public string Description { get; set; }

    [Required] public int Status { get; set; } = 0;

    [ForeignKey("CapstoneWorkspace")][Required] public int CapstoneWorkspaceId { get; set; }
    
    public virtual CapstoneWorkspace CapstoneWorkspace { get; set; }
}