using MentorLink.Business.Dtos;
using MentorLink.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentorLink.Business.Services.IServices
{
    public interface ITaskListService
    {
        Task CreateAsync(TaskListDto taskListDto);
        Task<TaskListDto?> GetByIdAsync(int id);
        Task<IEnumerable<TaskListDto>> GetAllAsync();
        Task DeleteAsync(int id);
    }
}
