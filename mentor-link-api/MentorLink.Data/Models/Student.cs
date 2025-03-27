namespace MentorLink.Data.Models;

public class Student
{
    public int StudentId { get; set; }
    public string Major { get; set; } = string.Empty;
    public string University { get; set; } = string.Empty;
    public string Campus { get; set; } = string.Empty;
    public int SchoolYear { get; set; }
    public bool IsGraduated { get; set; }
    public string? StudentCard { get; set; }
    public int CapstoneWorkspaceId { get; set; }
    public CapstoneWorkspace CapstoneWorkspace { get; set; } = null!;
}