﻿using AutoMapper;
using MentorLink.Data.Models;
using MentorLink.Business.DTOs;

namespace MentorLink.Business.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TaskBoard, TaskBoardDTO>();
        CreateMap<CreateTaskBoardDTO, TaskBoard>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => 1));
        CreateMap<TaskBoard, UpdateTaskBoardDTO>();
    }
}