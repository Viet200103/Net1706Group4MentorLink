using MentorLink.Business.Database;
using MentorLink.Data.IRepositories;
using MentorLink.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MentorLink.Business.Repositories;

public class TaskBoardRepository(MentorLinkDbContext context) : ITaskBoardRepository
{
    public async Task<List<TaskBoard>> GetAllAsync()
    {
        return await context.TaskBoards.Include(t=> t.CapstoneWorkspace)
            .Where(t => t.Status == 1).ToListAsync();   
    }

    public async Task<TaskBoard?> GetByIdAsync(int id)
    {
        return await context.TaskBoards.Include(t => t.CapstoneWorkspace)
            .FirstOrDefaultAsync(t => t.TaskBoardId == id && t.Status == 1);
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