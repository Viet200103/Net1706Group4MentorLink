using System.ComponentModel.DataAnnotations.Schema;

namespace MentorLink.Data.Models;
[Table("Lecturer")]
public class Lecturer
{
    public int LecturerId { get; set; }
    public string Major { get; set; } = string.Empty;
    public string University { get; set; } = string.Empty;
    public string Campus { get; set; } = string.Empty;
    public string? Experience { get; set; }
    public string? Description { get; set; }
    public string UserId { get; set; }
    public User? User { get; set; } = null!;
    public List<LecturerWorkspace> LecturerWorkspaces { get; set; } = new();
}