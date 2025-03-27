using MentorLink.Data.Models.Dtos;

namespace MentorLink.Business.Services.IServices;

public interface INewsService
{
    Task<IEnumerable<NewsDto>> GetAllNewsAsync();
}