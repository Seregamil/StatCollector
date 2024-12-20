using StatCollector.Converters;
using StatCollector.Models;
using StatCollector.Repositories.Abstract;
using StatCollector.Services.Abstract;

namespace StatCollector.Services.Impl;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;
    
    public UsersService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }
    
    public async Task<CallerDto> GetUserInfo(string login)
    {
        var response = await _usersRepository.GetUserInfo(login);
        var result = response.ConvertToDto();
        return result;
    }

    public async Task<CallerDto> GetUserInfo(int id)
    {
        var response = await _usersRepository.GetUserInfo(id);
        var result = response.ConvertToDto();
        return result;
    }
}