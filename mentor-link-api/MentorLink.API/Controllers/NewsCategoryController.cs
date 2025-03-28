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
    private readonly ResponseDTO _response;

    public NewsCategoryController(INewsCategoryService service)
    {
        _service = service;
        _response = new ResponseDTO();
    }

    [HttpGet]
    public async Task<ResponseDTO> GetAsync()
    {
        try
        {
            IEnumerable<NewsCategoryDTO> categoryList = await _service.GetAllNewsCategoryAsync();
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