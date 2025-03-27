using MentorLink.Business.Dtos;

namespace MentorLink.Data.Models.Dtos;

public class NewsDto
{
    public int NewsId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int Author { get; set; }
    public DateTime PublicDate { get; set; }
    public int CategoryId { get; set; }
    public int Status { get; set; } = 0;
    public NewsCategoryDto NewsCategory { get; set; }
}