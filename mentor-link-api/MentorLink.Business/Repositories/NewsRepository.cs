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

    public async Task<News> GetNewsById(int id)
    {
        return await _dbContext.News.Include(n => n.NewsCategory).FirstOrDefaultAsync(n => n.NewsId == id) ??
               throw new InvalidOperationException();
    }

    public async Task<News> CreateNewsAsync(News news)
    {
        _dbContext.News.Add(news);
        await _dbContext.SaveChangesAsync();
        return news;
    }

    public async Task<bool> DeleteNewsAsync(int id)
    {
        _dbContext.News.Remove(_dbContext.News.FirstOrDefault(n => n.NewsId == id) ?? throw new InvalidOperationException());
        await _dbContext.SaveChangesAsync();
        return true;
    }
}