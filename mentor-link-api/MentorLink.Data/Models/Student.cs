using System.ComponentModel.DataAnnotations.Schema;

namespace MentorLink.Data.Models;
[Table("Student")]
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
    public int UserId { get; set; }
    public User? User { get; set; } = null!;
    public CapstoneWorkspace CapstoneWorkspace { get; set; } = null!;
}