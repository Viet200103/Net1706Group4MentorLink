using AutoMapper;
using MentorLink.Business.Dtos;
using MentorLink.Business.DTOs;
using MentorLink.Data.Models;
using MentorLink.Data.Models.Dtos;

namespace MentorLink.Business.Mapper;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<News, NewsDto>().ReverseMap();
        CreateMap<NewsCategory, NewsCategoryDto>().ReverseMap();
        CreateMap<CapstoneTopic, CapstoneTopicDTO>().ReverseMap();
    }
}