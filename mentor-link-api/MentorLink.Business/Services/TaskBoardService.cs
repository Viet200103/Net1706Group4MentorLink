using AutoMapper;
using MentorLink.Business.DTOs;
using MentorLink.Business.IServices;
using MentorLink.Data.IRepositories;
using MentorLink.Data.Models;

namespace MentorLink.Business.Services;

public class TaskBoardService(
    ITaskBoardRepository repository,
    ILecturerWorkSpaceRepository lecturerWorkSpaceRepository,
    IStudentRepository studentRepository,
    IMapper mapper)
    : ITaskBoardService
{
    private readonly ITaskBoardRepository _repository = repository;
    private readonly ILecturerWorkSpaceRepository _lecturerWorkSpaceRepository = lecturerWorkSpaceRepository;
    private readonly IStudentRepository _studentRepository = studentRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<TaskBoardDTO>> GetAllAsync()
    {
        var taskBoards = await _repository.GetAllAsync();
        if(taskBoards is null) throw new NullReferenceException();
        return _mapper.Map<List<TaskBoardDTO>>(taskBoards);
    }

    public async Task<TaskBoardDTO?> GetByIdAsync(int id)
    {
        var taskBoard = await _repository.GetByIdAsync(id);
        if(taskBoard is null) throw new NullReferenceException();
        return _mapper.Map<TaskBoardDTO>(taskBoard);
    }

    public async Task CreateTaskBoardAsync(CreateTaskBoardDTO taskBoard, int capstoneWorkspaceId)
    {
        var createTaskBoard = _mapper.Map<TaskBoard>(taskBoard);
        createTaskBoard.CapstoneWorkspaceId = capstoneWorkspaceId;
        await _repository.CreateTaskBoardAsync(createTaskBoard);
    }

    public async Task UpdateTaskBoardAsync(int taskBoardId, int userId, UpdateTaskBoardDTO taskBoard)
    {
        var lecturer = await _lecturerWorkSpaceRepository.GetLecturerWorkspaceById(userId, taskBoardId);
        if(lecturer is null) throw new NullReferenceException();
        var student = await _studentRepository.GetStudentByIdAsync(userId, taskBoardId);
        if(student is null) throw new NullReferenceException();
        var existingTaskBoard = await _repository.GetByIdAsync(taskBoardId);
        if (existingTaskBoard == null) throw new KeyNotFoundException("TaskBoard not found");
        existingTaskBoard.Title = taskBoard.Title;
        existingTaskBoard.Description = taskBoard.Description;
        await _repository.UpdateTaskBoardAsync(existingTaskBoard);
    }

    public async Task DeleteTaskBoardAsync(int userId, int taskBoardId)
    {
        var lecturer = await _lecturerWorkSpaceRepository.GetLecturerWorkspaceById(userId, taskBoardId);
        if(lecturer is null) throw new NullReferenceException();
        var student = await _studentRepository.GetStudentByIdAsync(userId, taskBoardId);
        if(student is null) throw new NullReferenceException();
        var existingTaskBoard = await _repository.GetByIdAsync(taskBoardId);
        if(existingTaskBoard == null) throw new KeyNotFoundException("TaskBoard not found");
        existingTaskBoard.Status = 0;
        await _repository.DeleteTaskBoardAsync(existingTaskBoard);
    }
}