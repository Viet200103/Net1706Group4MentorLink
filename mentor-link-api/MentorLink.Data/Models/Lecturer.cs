namespace MentorLink.Data.Models;

public class Lecturer
{
    public int LecturerId { get; set; }
    public string Major { get; set; } = string.Empty;
    public string University { get; set; } = string.Empty;
    public string Campus { get; set; } = string.Empty;
    public string? Experience { get; set; }
    public string? Description { get; set; }
    public List<LecturerWorkspace> LecturerWorkspaces { get; set; } = new();
}