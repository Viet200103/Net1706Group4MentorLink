using MentorLink.Data.Models;

namespace MentorLink.Data.IRepositories;

public interface INewsRepository
{
    Task<IEnumerable<News>> GetAllNewsAsync();
    Task<News> GetNewsById(int id);
}