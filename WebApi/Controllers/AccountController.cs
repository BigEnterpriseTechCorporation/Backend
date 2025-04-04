using System.Security.Claims;
using ApplicationCore.DTOs.Requests;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;


    public AccountController(IUserService userService, ITokenService tokenService, IUserRepository userRepository)
    {
        _userService = userService;
        _tokenService = tokenService;
        _userRepository = userRepository;
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterRequest rq)
    {
        var user = new User
        {
            UserName = rq.UserName,
            Email = $"{rq.UserName}@localhost",
        };
        
        try
        {
            var createdUser = await _userService.RegisterUserAsync(user, rq.Password);
            return CreatedAtAction(nameof(Register), new { id = createdUser.Id }, createdUser);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginRequest rq)
    {
        var isValid = _userService.ValidateCredentialsAsync(rq.username, rq.password);
        if (!await isValid)
           return Unauthorized();
        User? user = await _userRepository.GetByUsernameAsync(rq.username);
        return Ok(new
        {
            Token = _tokenService.GenerateJwtToken(user)
        });
    }

    [HttpGet("self")]
    [Authorize]
    public async Task<IActionResult> GetSelf()
    {
        var claims = HttpContext.User.Claims;
        var idStr = claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        if (idStr == null) return BadRequest();
        Guid.TryParseExact(idStr, "D", out var id);
        var user = await _userRepository.GetByIdAsync(id);
        return Ok(user);
    }
}