using MentorLink.Data.IRepositories;
using MentorLink.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MentorLink.Business.Repositories;

public class NewsRepository : INewsRepository
{
    private readonly MentorLinkDbContext _dbContext;

    public NewsRepository(MentorLinkDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<News>> GetAllNewsAsync()
    {
        return await _dbContext.News.Include(n => n.NewsCategory).ToListAsync();
    }
}