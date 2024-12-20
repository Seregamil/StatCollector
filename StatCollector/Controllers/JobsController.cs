using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ServiceMan.BaseLibrary.Models;
using StatCollector.Data;
using StatCollector.Models;
using StatCollector.Services.Abstract;

namespace StatCollector.Controllers;

[ApiController]
[Route("v1/jobs")]
public class JobsController
{
    private readonly IJobsService _jobsService;
    
    public JobsController(IJobsService jobsService)
    {
        _jobsService = jobsService;
    }
    
    [HttpGet]
    [Route(("{jobId:int}"))]
    public async Task<BaseResultDto<JobDto>> GetJobInfo(int jobId)
    {
        var response = await _jobsService.GetJob(jobId);
        return new BaseResultDto<JobDto>(response);
    }
    
    [HttpPost]
    public async Task<BaseResultDto<JobDto>> AddJobInfo([FromBody] JobDto jobDto)
    {
        var response = await _jobsService.CreateJob(jobDto);
        return new BaseResultDto<JobDto>(response);
    }
}