using StatCollector.Data;

namespace StatCollector.Repositories.Abstract;

public interface IUsersRepository
{
    /// <summary>
    /// Find user in database by login
    /// </summary>
    Task<Caller> GetUserInfo(string login);
    
    /// <summary>
    /// Find user in database by dbId
    /// </summary>
    Task<Caller> GetUserInfo(int id);

    /// <summary>
    /// Add new caller into db
    /// </summary>
    Task<Caller> AddCaller(Caller caller);
}