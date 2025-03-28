using MentorLink.Business.DTOs;
using MentorLink.Business.IServices;
using MentorLink.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MentorLink.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TaskBoardController(ITaskBoardService service) : ControllerBase
{
    private readonly ITaskBoardService _service = service;
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var taskBoards = await _service.GetAllAsync();
        return Ok(taskBoards);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetTaskBoardById(int id)
    {
        var taskBoard = await _service.GetByIdAsync(id);
        if (taskBoard == null) 
            return NotFound("TaskBoard not found.");

        return Ok(taskBoard);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateTaskBoard([FromBody] CreateTaskBoardDTO taskBoard, int capstoneWorkspaceId)
    {
        if (taskBoard == null)
        {
            return BadRequest("Invalid task board data.");
        }

        try
        {
            await _service.CreateTaskBoardAsync(taskBoard, capstoneWorkspaceId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }
    
    [HttpPut("{taskBoardId:int}")]
    public async Task<IActionResult> UpdateTaskBoard(int taskBoardId,int userId, [FromBody] UpdateTaskBoardDTO taskBoard)
    {
        if (taskBoard == null)
        {
            return BadRequest("Invalid task board data.");
        }

        try
        {
            await _service.UpdateTaskBoardAsync(taskBoardId, userId, taskBoard);
            return NoContent(); 
        }
        catch (NullReferenceException)
        {
            return NotFound($"TaskBoard with id {taskBoardId} not found.");
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }
    
    [HttpDelete("{taskBoardId:int}")]
    public async Task<IActionResult> DeleteTaskBoard(int taskBoardId, int userId)
    {
        try
        {
            await _service.DeleteTaskBoardAsync(userId, taskBoardId);
            return Ok(); 
        }
        catch (NullReferenceException)
        {
            return NotFound($"TaskBoard with id {taskBoardId} or user not found.");
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }
    
}