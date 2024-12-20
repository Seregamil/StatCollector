using StatCollector.Data;

namespace StatCollector.Repositories.Abstract;

public interface IJobsRepository
{
    /// <summary>
    /// Find job info by id in database
    /// </summary>
    /// <param name="id">Database increment id</param>
    /// <returns>Job contract</returns>
    Task<Job> GetJob(int id);

    /// <summary>
    /// Apply new jobInfo
    /// </summary>
    /// <returns>Job from database with Id</returns>
    Task<Job> CreateJob(Job job);
}