using MentorLink.Data.Models;

namespace MentorLink.Data.IRepositories;

public interface INewsCategoryRepository
{
    Task<NewsCategory> GetNewsCategoryById(int newsDtoCategoryId);
}