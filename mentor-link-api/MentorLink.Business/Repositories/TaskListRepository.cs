using MentorLink.Data.IRepositories;
using MentorLink.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MentorLink.Business.Repositories
{
    public class TaskListRepository : ITaskListRepository
    {
        private readonly MentorLinkDbContext _context;

        public TaskListRepository(MentorLinkDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(TaskList taskList)
        {
            await _context.TaskLists.AddAsync(taskList);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.TaskLists.FindAsync(id);
            if (entity != null)
            {
                _context.TaskLists.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TaskList>> GetAllAsync()
        {
            return await _context.TaskLists
                .Include(t => t.TaskBoard)
                .ToListAsync();
        }

        public Task<TaskList?> GetByIdAsync(int id)
        {
            return _context.TaskLists
                .Include(t => t.TaskBoard)
                .FirstOrDefaultAsync(t => t.TaskListId == id);
        }
    }
}
