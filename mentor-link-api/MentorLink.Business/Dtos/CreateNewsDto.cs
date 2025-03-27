namespace MentorLink.Business.Dtos;

public class CreateNewsDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    public int Author { get; set; }
    public int CategoryId { get; set; }
    public int Status { get; set; } = 0;
}