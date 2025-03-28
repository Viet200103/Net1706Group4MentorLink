using MentorLink.Business.DTOs;
using MentorLink.Data.Models;

namespace MentorLink.Business.IServices;

public interface ITaskBoardService
{
    Task<List<TaskBoardDTO>> GetAllAsync();
    Task<TaskBoardDTO?> GetByIdAsync(int id);
    
    Task CreateTaskBoardAsync(CreateTaskBoardDTO taskBoard, int capstoneWorkspaceId);
    Task UpdateTaskBoardAsync(int taskBoardId,int userId, UpdateTaskBoardDTO taskBoard);
    Task DeleteTaskBoardAsync(int userId, int taskBoardId);
}