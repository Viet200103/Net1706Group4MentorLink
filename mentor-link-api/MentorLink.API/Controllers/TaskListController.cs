using AutoMapper;
using MentorLink.Business.Dtos;
using MentorLink.Business.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace MentorLink.API.Controllers
{
    [Route("api/tasklist")]
    [ApiController]
    public class TaskListController : ControllerBase
    {
        private readonly ITaskListService _taskListService;

        public TaskListController(ITaskListService taskListService)
        {
            _taskListService = taskListService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto>> GetAllAsync()
        {
            var response = new ResponseDto();
            try
            {
                response.Result = await _taskListService.GetAllAsync();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                return StatusCode(500, response);
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto>> GetByIdAsync(int id)
        {
            var response = new ResponseDto();
            try
            {
                var taskList = await _taskListService.GetByIdAsync(id);
                if (taskList == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Task list not found!";
                    return NotFound(response);
                }

                response.Result = taskList;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                return StatusCode(500, response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto>> CreateAsync([FromBody] TaskListDto taskListDto)
        {
            var response = new ResponseDto();
            try
            {
                if (taskListDto == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Task list cannot be null!";
                    return BadRequest(response);
                }

                if (!ModelState.IsValid)
                {
                    response.IsSuccess = false;
                    response.Message = "Invalid data";
                    return BadRequest(response);
                }

                await _taskListService.CreateAsync(taskListDto);
                response.Result = taskListDto;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                return StatusCode(500, response);
            }
            return Ok(response);
        }
    }
}
