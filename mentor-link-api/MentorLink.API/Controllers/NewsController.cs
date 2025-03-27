using AutoMapper;
using MentorLink.Business.Services.IServices;
using MentorLink.Data.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MentorLink.API.Controllers;

[Route("api/news")]
[ApiController]
public class NewsController
{
    private INewsService _service;
    private ResponseDto _response;

    public NewsController(INewsService service)
    {
        _service = service;
        _response = new ResponseDto();
    }

    [HttpGet]
    public async Task<ResponseDto> Get()
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
}