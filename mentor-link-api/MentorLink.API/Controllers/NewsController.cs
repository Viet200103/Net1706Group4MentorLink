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
    private ResponseDto _response;

    public NewsController(INewsService service)
    {
        _service = service;
        _response = new ResponseDto();
    }

    [HttpGet]
    public async Task<ResponseDto> GetAsync()
    {
        try
        {
            IEnumerable<NewsDto> newsList = await _service.GetAllNewsAsync();
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
    public async Task<ResponseDto> GetAsync(int id)
    {
        try
        {
            NewsDto newsDto = await _service.GetNewsById(id);
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
    public async Task<ResponseDto> PostAsync([FromBody] CreateNewsDto newsDto)
    {
        try
        {
            NewsDto result = await _service.CreateNewsAsync(newsDto);
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
    public async Task<ResponseDto> DeleteAsync(int id)
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