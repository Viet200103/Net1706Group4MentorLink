using AutoMapper;
using MentorLink.Business.Dtos;
using MentorLink.Business.Services.IServices;
using MentorLink.Data.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MentorLink.API.Controllers;

[Route("api/news")]
[ApiController]
public class NewsController : ControllerBase
{
    private INewsService _service;
    private ResponseDTO _response;

    public NewsController(INewsService service)
    {
        _service = service;
        _response = new ResponseDTO();
    }

    [HttpGet]
    public async Task<ResponseDTO> GetAsync()
    {
        try
        {
            IEnumerable<NewsDTO> newsList = await _service.GetAllNewsAsync();
            _response.Result = newsList;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }

        return _response;
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ResponseDTO> GetAsync(int id)
    {
        try
        {
            NewsDTO newsDto = await _service.GetNewsById(id);
            _response.Result = newsDto;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }
        return _response;
    }

    [HttpPost]
    public async Task<ResponseDTO> PostAsync([FromBody] CreateNewsDTO newsDto)
    {
        try
        {
            NewsDTO result = await _service.CreateNewsAsync(newsDto);
            _response.Result = result;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.StackTrace;
        }

        return _response;
    }
    
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ResponseDTO> DeleteAsync(int id)
    {
        try
        {
            bool r = await _service.DeleteNewsAsync(id);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }
        return _response;
    }
}