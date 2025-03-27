using MentorLink.Business.Dtos;

namespace MentorLink.Business.Services.IServices;

public interface INewsCategoryService
{
    Task<IEnumerable<NewsCategoryDto>> GetAllNewsCategoryAsync();
}