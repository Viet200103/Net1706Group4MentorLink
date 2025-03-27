namespace MentorLink.Data.Models.Dtos;

namespace MentorLink.Business.Dtos
{
public class ResponseDto
{
    public object? Result { get; set; }
    public bool IsSuccess { get; set; } = true;
    public string Message { get; set; } = "";
}
}
