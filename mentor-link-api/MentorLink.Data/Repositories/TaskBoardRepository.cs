using MentorLink.Data.IRepository;
using MentorLink.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MentorLink.Data.Repositories;

public class TaskBoardRepository(ApplicationDbContext context) : ITaskBoardRepository
{
    public async Task<List<TaskBoard>> GetAllAsync()
    {
        return await context.TaskBoards.Include(t=> t.CapstoneWorkspace)
            .Where(t => t.Status == true).ToListAsync();   
    }

    public async Task<TaskBoard?> GetByIdAsync(int id)
    {
        return await context.TaskBoards.Include(t => t.CapstoneWorkspace)
            .FirstOrDefaultAsync(t => t.TaskBoardId == id && t.Status == true);
    }

    public async Task CreateTaskBoardAsync(TaskBoard taskBoard)
    {
        context.TaskBoards.Add(taskBoard);
        await context.SaveChangesAsync();  
    }

    public async Task UpdateTaskBoardAsync(TaskBoard taskBoard)
    {
        context.TaskBoards.Update(taskBoard);
        await context.SaveChangesAsync();
    }

    public async Task DeleteTaskBoardAsync(TaskBoard taskBoard)
    {
        context.TaskBoards.Update(taskBoard);
        await context.SaveChangesAsync();
    }
}