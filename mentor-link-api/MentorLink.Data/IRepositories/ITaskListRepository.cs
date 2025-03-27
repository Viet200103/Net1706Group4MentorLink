using MentorLink.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentorLink.Data.IRepositories
{
    public interface ITaskListRepository
    {
        Task CreateAsync(TaskList taskList);
        Task<TaskList?> GetByIdAsync(int id);
        Task<IEnumerable<TaskList>> GetAllAsync();
        Task DeleteAsync(int id);
    }
}
