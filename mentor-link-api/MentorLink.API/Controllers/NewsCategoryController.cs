using MentorLink.Business.Dtos;
using MentorLink.Business.Services.IServices;
using MentorLink.Data.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MentorLink.API.Controllers;

[Route("api/newscategory")]
[ApiController]
public class NewsCategoryController : ControllerBase
{
    private readonly INewsCategoryService _service;
    private readonly ResponseDto _response;

    public NewsCategoryController(INewsCategoryService service)
    {
        _service = service;
        _response = new ResponseDto();
    }

    [HttpGet]
    public async Task<ResponseDto> GetAsync()
    {
        try
        {
            IEnumerable<NewsCategoryDto> categoryList = await _service.GetAllNewsCategoryAsync();
            _response.Result = categoryList;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }

        return _response;
    }
}