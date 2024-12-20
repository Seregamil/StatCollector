using Microsoft.AspNetCore.Mvc;
using ServiceMan.BaseLibrary.Models;
using StatCollector.Models;
using StatCollector.Services.Abstract;

namespace StatCollector.Controllers;

[ApiController]
[Route("v1/users")]
public class UsersController
{
    private readonly IUsersService _usersService;
    
    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }
    
    [HttpGet]
    [Route(("{login}"))]
    public async Task<BaseResultDto<CallerDto>> GetUserInfo(string login)
    {
        var response = await _usersService.GetUserInfo(login);
        return new BaseResultDto<CallerDto>(response);
    }
}