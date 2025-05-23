using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : Controller
{
    private readonly IUserService _userService;
    public AuthController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        if (registerRequest == null)
        {
            return BadRequest("Invalid reqistration data");
        }
        
        AuthenticationResponse? response = await _userService.Register(registerRequest);

        if (response == null || response.Success == false)
        {
            return BadRequest(response);
        }
        
        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> login(LoginRequest loginRequest)
    {
        if (loginRequest == null)
        {
            return BadRequest("Invalid login data");
        }
        
        AuthenticationResponse? response = await _userService.Login(loginRequest);

        if (response == null || response.Success == false)
        {
            return Unauthorized(response);
        }
        
        return Ok(response);
    }
}