namespace MentorLink.Business.DTOs;

public class CreateTaskBoardDTO
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
}