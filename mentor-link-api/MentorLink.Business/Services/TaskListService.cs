using AutoMapper;
using MentorLink.Business.Dtos;
using MentorLink.Business.Services.IServices;
using MentorLink.Data.IRepositories;
using MentorLink.Data.Models;

namespace MentorLink.Business.Services
{
    public class TaskListService : ITaskListService
    {
        private readonly ITaskListRepository _taskListRepository;
        private readonly IMapper _mapper;

        public TaskListService(ITaskListRepository taskListRepository, IMapper mapper)
        {
            _taskListRepository = taskListRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(TaskListDto taskListDto)
        {
            var taskList = _mapper.Map<TaskList>(taskListDto);

            await _taskListRepository.CreateAsync(taskList);
        }

        public async Task DeleteAsync(int id)
        {
            var taskList = _taskListRepository.GetByIdAsync(id);
            if (taskList == null)
            {
                throw new ArgumentNullException("Task list was not found!");
            }

            await _taskListRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<TaskListDto>> GetAllAsync()
        {
            var tasks = await _taskListRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<TaskListDto>>(tasks);
        }

        public async Task<TaskListDto?> GetByIdAsync(int id)
        {
            var task = await _taskListRepository.GetByIdAsync(id);

            if (task == null)
            {
                return null;
            }

            return _mapper.Map<TaskListDto>(task);
        }
    }
}
