namespace MentorLink.Data.Models;

public class TaskBoard
{
    public int TaskBoardId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool? Status { get; set; }

    public int CapstoneWorkspaceId { get; set; }
    public CapstoneWorkspace CapstoneWorkspace { get; set; } = null!;
}