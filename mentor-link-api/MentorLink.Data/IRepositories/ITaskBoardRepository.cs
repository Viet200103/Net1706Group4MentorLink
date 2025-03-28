﻿using MentorLink.Data.Models;

namespace MentorLink.Data.IRepositories;

public interface ITaskBoardRepository
{
    Task<List<TaskBoard>> GetAllAsync();
    Task<TaskBoard?> GetByIdAsync(int id);
    
    Task CreateTaskBoardAsync(TaskBoard taskBoard);
    Task UpdateTaskBoardAsync(TaskBoard taskBoard);
    Task DeleteTaskBoardAsync(TaskBoard taskBoard);
}