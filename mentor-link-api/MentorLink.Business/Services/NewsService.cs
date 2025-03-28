using System.Text.Json;
using AutoMapper;
using MentorLink.Business.Dtos;
using MentorLink.Business.Services.IServices;
using MentorLink.Data.IRepositories;
using MentorLink.Data.Models;
using MentorLink.Data.Models.Dtos;

namespace MentorLink.Business.Services;

public class NewsService : INewsService
{
    private readonly INewsRepository _repository;
    private readonly INewsCategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public NewsService(INewsRepository repository, IMapper mapper, INewsCategoryRepository categoryRepository)
    {
        _repository = repository;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<NewsDTO>> GetAllNewsAsync()
    {
        IEnumerable<News> newsList = await _repository.GetAllNewsAsync();
        
        foreach (var news in newsList)
        {
            news.Content = DeserializeContent(news.Content);
        }

        return _mapper.Map<IEnumerable<NewsDTO>>(newsList);
    }

    public async Task<NewsDTO> GetNewsById(int id)
    {
        News news = await _repository.GetNewsById(id);
        
        if (news == null)
        {
            throw new InvalidOperationException("News not found");
        }

        news.Content = DeserializeContent(news.Content);
        
        return _mapper.Map<NewsDTO>(news);
    }

    public async Task<NewsDTO> CreateNewsAsync(CreateNewsDTO newsDto)
    {
        News news = new News();

        string newsContent = JsonSerializer.Serialize(new { body = newsDto.Content });
        
        news.CategoryId = newsDto.CategoryId;
        news.Author = newsDto.Author;
        news.Title = newsDto.Title;
        news.Content = newsContent;
        news.Status = newsDto.Status;

        NewsCategory newsCategory = await _categoryRepository.GetNewsCategoryById(newsDto.CategoryId);

        news.NewsCategory = newsCategory;

        News result = await _repository.CreateNewsAsync(news);

        return _mapper.Map<NewsDTO>(result);
    }

    public async Task<bool> DeleteNewsAsync(int id)
    {
        return await _repository.DeleteNewsAsync(id);
    }

    private string DeserializeContent(string jsonContent)
    {
        try
        {
            var jsonObject = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonContent);
            return jsonObject?["body"] ?? string.Empty;
        }
        catch
        {
            return jsonContent;
        }
    }
}