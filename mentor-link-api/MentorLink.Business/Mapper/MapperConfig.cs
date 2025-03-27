using AutoMapper;
using MentorLink.Business.Dtos;
using MentorLink.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentorLink.Business.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<TaskList, TaskListDto>().ReverseMap();
        }
    }
}
