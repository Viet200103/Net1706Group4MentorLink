using MentorLink.Business.Dtos;
using MentorLink.Data.Models.Dtos;

namespace MentorLink.Business.Services.IServices;

public interface INewsService
{
    Task<IEnumerable<NewsDto>> GetAllNewsAsync();
    Task<NewsDto> GetNewsById(int id);
    Task<NewsDto> CreateNewsAsync(CreateNewsDto newsDto);
    Task<bool> DeleteNewsAsync(int id);
}