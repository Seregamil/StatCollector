using StatCollector.Models;

namespace StatCollector.Services.Abstract;

public interface IUsersService
{
    /// <summary>
    /// Find user in database by login
    /// </summary>
    Task<CallerDto> GetUserInfo(string login);
    
    /// <summary>
    /// Find user in database by dbId
    /// </summary>
    Task<CallerDto> GetUserInfo(int id);
}