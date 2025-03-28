using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MentorLink.Data.Models;

[Table("CapstoneWorkspace")]
public partial class CapstoneWorkspace
{
    [Key] public int CapstoneWorkspaceId { get; set; }

    [Required] [MaxLength(255)] public string Name { get; set; }

    [Required] public int Status { get; set; } = 0;

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    [MaxLength(100)] [Required] public string WorkspaceCode { get; set; }
    
    public virtual ICollection<TaskBoard>  TaskBoards { get; set; }
    public List<Student> Students { get; set; } 
    public List<LecturerWorkspace> LecturerWorkspaces { get; set; } 
}