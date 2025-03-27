using MentorLink.Data.Models;

namespace MentorLink.Business.DTOs;

public class TaskBoardDTO
{
    public int TaskBoardId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }

    public string CapstoneWorkspaceName { get; set; }
}