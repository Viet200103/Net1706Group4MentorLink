using AutoMapper;
using MentorLink.Business.Dtos;
using MentorLink.Business.Services.IServices;
using MentorLink.Data.IRepositories;
using MentorLink.Data.Models;

namespace MentorLink.Business.Services;

public class NewsCategoryService :  INewsCategoryService
{
    private readonly INewsCategoryRepository _repository;
    private readonly IMapper _mapper;

    public NewsCategoryService(INewsCategoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<NewsCategoryDTO>> GetAllNewsCategoryAsync()
    {
        IEnumerable<NewsCategory> categoryList = await _repository.GetAllNewsCategoryAsync();
        return _mapper.Map<IEnumerable<NewsCategoryDTO>>(categoryList);
    }
}