using MentorLink.Business.Database;
using MentorLink.Data.IRepositories;
using MentorLink.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MentorLink.Business.Repositories;

public class NewsCategoryRepository : INewsCategoryRepository
{
    private readonly MentorLinkDbContext _dbContext;

    public NewsCategoryRepository(MentorLinkDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<NewsCategory> GetNewsCategoryById(int newsDtoCategoryId)
    {
        return await _dbContext.NewsCategories.FirstOrDefaultAsync(c => c.CategoryId == newsDtoCategoryId) ?? throw new
            InvalidOperationException();
    }

    public async Task<IEnumerable<NewsCategory>> GetAllNewsCategoryAsync()
    {
        return await _dbContext.NewsCategories.ToListAsync();
    }
}