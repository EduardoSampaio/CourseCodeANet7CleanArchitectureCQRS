using HRLeaveManagement.Application.Contracts.Identity;
using HRLeaveManagement.Application.Models.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HRLeaveManagement.Api.Controllers;
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
    {
        return Ok(await _authService.Login(request));
    }

    [HttpPost("register")]
    public async Task<ActionResult<AuthResponse>> Register(RegistrationRequest request)
    {
        return Ok(await _authService.Register(request));
    }
}
