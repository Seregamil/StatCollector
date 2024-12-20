using StatCollector.Data;
using StatCollector.Models;

namespace StatCollector.Converters;

public static class CallerConverter
{
    public static CallerDto ConvertToDto(this Caller caller)
        => new()
        {
            Login = caller.Login,
            Name = caller.Name,
            Email = caller.Email,
            ExecutedJobs = caller.ExecutedJobs.Select(x => x.Id)
        };

    public static Caller ConvertFromDto(this CallerDto callerDto)
        => new()
        {
            Login = callerDto.Login,
            Name = callerDto.Name,
            Email = callerDto.Email,
        };
}