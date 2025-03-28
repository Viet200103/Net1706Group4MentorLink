using AutoMapper;
using MentorLink.Business.Dtos;
using MentorLink.Data.Models;
using MentorLink.Data.Models.Dtos;

namespace MentorLink.Business.Mapper;

public class CommonMapperProfile : Profile
{
    public CommonMapperProfile()
    {
        CreateMap<News, NewsDTO>().ReverseMap();
        CreateMap<NewsCategory, NewsCategoryDTO>().ReverseMap();
    }
}