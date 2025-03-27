using AutoMapper;
using MentorLink.Business.Services.IServices;
using MentorLink.Data.IRepositories;
using MentorLink.Data.Models;
using MentorLink.Data.Models.Dtos;

namespace MentorLink.Business.Services;

public class NewsService : INewsService
{
    private readonly INewsRepository _repository;
    private readonly IMapper _mapper;

    public NewsService(INewsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<NewsDto>> GetAllNewsAsync()
    {
        IEnumerable<News> newsList = await _repository.GetAllNewsAsync();
        return _mapper.Map<IEnumerable<NewsDto>>(newsList);
    }

    public async Task<NewsDto> GetNewsById(int id)
    {
        News news= await _repository.GetNewsById(id);
        return _mapper.Map<NewsDto>(news);
    }
}