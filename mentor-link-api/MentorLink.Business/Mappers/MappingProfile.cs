using AutoMapper;
using MentorLink.Data.Models;
using MentorLink.Business.DTOs;

namespace MentorLink.Business.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TaskBoard, TaskBoardDTO>();
        CreateMap<CreateTaskBoardDTO, TaskBoard>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => true));
        // CreateMap<UpdateTaskBoardDTO, TaskBoard>()
        //     .ForMember(dest => dest.TaskBoardId, opt => opt.Ignore())
        //     .ForMember(dest => dest.Status, opt => opt.Ignore())
        //     .ForMember(dest => dest.CapstoneWorkspaceId, opt => opt.Ignore());
        CreateMap<TaskBoard, UpdateTaskBoardDTO>();
    }
}