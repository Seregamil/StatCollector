using Microsoft.EntityFrameworkCore;
using Serilog;
using ServiceMan.BaseLibrary.Exceptions;
using StatCollector.Data;
using StatCollector.Repositories.Abstract;

namespace StatCollector.Repositories.Impl;

public class JobsRepository : IJobsRepository
{
    private readonly PipelineContext _context;

    public JobsRepository(PipelineContext context)
    {
        _context = context;
    }
    
    public async Task<Job> GetJob(int id)
    {
        var result = await _context.Jobs
                         .Include(x => x.Caller)
                         .ThenInclude(x => x.ExecutedJobs)
                         .FirstOrDefaultAsync(x => x.Id == id)
                     ?? throw new NotFoundedException($"Job with Id {id} not founded");

        return result;
    }

    public async Task<Job> CreateJob(Job job)
    {
        await _context.Jobs.AddAsync(job);
        await _context.SaveChangesAsync();

        return job;
    }
}