using Microsoft.AspNetCore.Mvc;

namespace MentorLink.API.Controllers;

[Route("api/v1/auth")]
[ApiController]
public class AuthController: ControllerBase
{


    [Route("login")]
    [HttpPost]
    public Task<IActionResult> Login()
    {
        var a = 10;
        return Task.FromResult<IActionResult>(Ok());
    }
    
}