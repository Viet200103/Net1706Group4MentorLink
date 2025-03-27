namespace MentorLink.Data.Models;

public class LecturerWorkspace
{
    public int WorkspaceId { get; set; }
    public CapstoneWorkspace CapstoneWorkspace { get; set; } = null!;

    public int LecturerId { get; set; }
    public Lecturer Lecturer { get; set; } = null!;
}