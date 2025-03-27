using AutoMapper;
using MentorLink.Business.Dtos;
using MentorLink.Data.Models;
using MentorLink.Data.Models.Dtos;

namespace MentorLink.Business.Mapper;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<News, NewsDto>().ReverseMap();
        CreateMap<NewsCategory, NewsCategoryDto>().ReverseMap();
    }
}