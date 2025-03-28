using MentorLink.API.Security;
using MentorLink.API.Utils;
using MentorLink.Business.Dtos;
using MentorLink.Business.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace MentorLink.API.Controllers;

[Route("api/v1/auth")]
[ApiController]
public class AuthController(IAuthService authService): ControllerBase
{


    [Route("login")]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
    {
        try
        {
            AccessToken token = await authService.Login(loginRequestDTO);
            return Ok(token);
        }
        catch (Exception e)
        {
            throw e;
            return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
        }
    }
    
}