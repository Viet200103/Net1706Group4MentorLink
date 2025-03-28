using MentorLink.Business.Dtos;
using MentorLink.Data.Models.Dtos;

namespace MentorLink.Business.Services.IServices;

public interface INewsService
{
    Task<IEnumerable<NewsDTO>> GetAllNewsAsync();
    Task<NewsDTO> GetNewsById(int id);
    Task<NewsDTO> CreateNewsAsync(CreateNewsDTO newsDto);
    Task<bool> DeleteNewsAsync(int id);
}