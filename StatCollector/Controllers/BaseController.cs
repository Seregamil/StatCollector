using Microsoft.AspNetCore.Mvc;
using ServiceMan.BaseLibrary.Models;

namespace StatCollector.Controllers;

[ApiController]
public class BaseController : ControllerBase
{
    private readonly IConfiguration _configuration;
    
    public BaseController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    [Route("health")]
    public async Task<IActionResult> HealthCheck()
    {
        return await Task.FromResult(Ok());
    } 

    [HttpGet]
    [Route("info")]
    public async Task<BaseResultDto<ServiceInfoDto>> InfoMap()
    {
        var name = _configuration.GetValue<string>("Service:Name", "StatCollector Service");
        var version = _configuration.GetValue<string>("Service:Version", defaultValue: "1.0.0");

        var svcInfo = new ServiceInfoDto(name, version);
        return new BaseResultDto<ServiceInfoDto>(svcInfo);
    } 
}