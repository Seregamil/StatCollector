using StatCollector.Data;
using StatCollector.Models;

namespace StatCollector.Converters;

public static class JobConverter
{
    public static Job ConvertFromDto(this JobDto jobDto)
        => new()
        {
            Id = jobDto.Id,
            Name = jobDto.Name,
            BuildId = jobDto.BuildId,
            CallerId = jobDto.Caller.ConvertFromDto().Id,
            Url = jobDto.Url,
            Status = jobDto.Status,
            Stages = jobDto.Stages,
            Caller = jobDto.Caller.ConvertFromDto(),
        };

    public static JobDto ConvertToDto(this Job job)
        => new()
        {
            Id = job.Id,
            Name = job.Name,
            BuildId = job.BuildId,
            Url = job.Url,
            Status = job.Status,
            Stages = job.Stages,
            Caller = job.Caller.ConvertToDto()
        };
}