using StatCollector.Models;

namespace StatCollector.Services.Abstract;

public interface IJobsService
{
    /// <summary>
    /// Find job info by id in database
    /// </summary>
    /// <param name="id">Database increment id</param>
    /// <returns>Job contract</returns>
    Task<JobDto> GetJob(int id);

    /// <summary>
    /// Apply new jobInfo
    /// </summary>
    /// <returns>Job from database with Id</returns>
    Task<JobDto> CreateJob(JobDto job);
}