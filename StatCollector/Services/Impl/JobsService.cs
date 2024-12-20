using System.Threading.Tasks.Dataflow;
using Serilog;
using StatCollector.Converters;
using StatCollector.Models;
using StatCollector.Repositories.Abstract;
using StatCollector.Services.Abstract;

namespace StatCollector.Services.Impl;

public class JobsService : IJobsService
{
    private readonly IJobsRepository _jobsRepository;
    private readonly IUsersRepository _usersRepository;
    
    public JobsService(IJobsRepository jobsRepository,
        IUsersRepository usersRepository)
    {
        _jobsRepository = jobsRepository;
        _usersRepository = usersRepository;
    }
    
    public async Task<JobDto> GetJob(int id)
    {
        var response = await _jobsRepository.GetJob(id);
        var result = response.ConvertToDto();
        return result;
    }

    public async Task<JobDto> CreateJob(JobDto job)
    {
        var model = job.ConvertFromDto();
        var caller = await _usersRepository.AddCaller(model.Caller);

        model.Caller = null;
        model.CallerId = caller.Id;
        
        Log.Information("Selected caller {id}", model.CallerId);
        var response = await _jobsRepository.CreateJob(model);
       
        response.Caller = caller;
        
        var result = response.ConvertToDto();
        return result;
    }
}