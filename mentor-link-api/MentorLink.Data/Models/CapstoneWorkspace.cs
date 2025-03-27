namespace MentorLink.Data.Models;

public class CapstoneWorkspace
{
    public int CapstoneWorkspaceId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Status { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? WorkspaceCode { get; set; }

    public List<TaskBoard> TaskBoards { get; set; } 
    public List<Student> Students { get; set; } 
    public List<LecturerWorkspace> LecturerWorkspaces { get; set; } 
}