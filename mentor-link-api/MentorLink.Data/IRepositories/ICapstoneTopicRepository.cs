using MentorLink.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentorLink.Data.IRepositories
{
    public interface ICapstoneTopicRepository
    {
        Task<IEnumerable<CapstoneTopic>> GetAllCapstoneTopicAsync();
        Task<CapstoneTopic> GetCapstoneTopicById(int id);
        Task<CapstoneTopic> CreateCapstoneTopicAsync(CapstoneTopic capstoneTopic);
        Task<bool> DeleteCapstoneTopic(int id);
        Task<CapstoneTopic> ApproveTopic(CapstoneTopic capstoneTopic);
    }
}
