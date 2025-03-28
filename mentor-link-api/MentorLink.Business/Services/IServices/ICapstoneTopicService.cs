using MentorLink.Business.DTOs;
using MentorLink.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentorLink.Business.Services.IService
{
    public interface ICapstoneTopicService
    {
        Task<IEnumerable<CapstoneTopicDTO>> GetCapstoneTopics();
        Task<CapstoneTopicDTO> GetCapstoneTopicById(int id);
        Task<CapstoneTopicDTO> CreateCapstoneTopicAsync(CapstoneTopicDTO capstoneTopicDTO);
        Task<bool> DeleteCapstoneTopicAsync(int id);
        Task<CapstoneTopicDTO> ApproveTopic(int id, int status);
    }
}
