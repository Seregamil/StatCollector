using Microsoft.EntityFrameworkCore;
using ServiceMan.BaseLibrary.Exceptions;
using StatCollector.Data;
using StatCollector.Repositories.Abstract;

namespace StatCollector.Repositories.Impl;

public class UsersRepository : IUsersRepository
{
    private readonly PipelineContext _context;
    
    public UsersRepository(PipelineContext context)
    {
        _context = context;
    }
    
    public async Task<Caller> GetUserInfo(string login)
    {
        var response = await _context.Callers
                           .AsNoTracking()
                           .Include(x => x.ExecutedJobs)
                           .FirstOrDefaultAsync(x => x.Login == login)
                       ?? throw new NotFoundedException($"User with login {login} not founded");

        return response;
    }

    public async Task<Caller> GetUserInfo(int id)
    {
        var response = await _context.Callers
                           .AsNoTracking()
                           .Include(x => x.ExecutedJobs)
                           .FirstOrDefaultAsync(x => x.Id == id)
                       ?? throw new NotFoundedException($"User with id {id} not founded");

        return response;
    }

    public async Task<Caller> AddCaller(Caller caller)
    {
        var dbCaller = await _context.Callers
            .AsNoTracking()
            .Include(x => x.ExecutedJobs)
            .FirstOrDefaultAsync(x => x.Login == caller.Login);

        if (dbCaller is not null) 
            return dbCaller;

        await _context.Callers.AddAsync(caller);
        await _context.SaveChangesAsync();

        caller.ExecutedJobs = new List<Job>();
        return caller;
    }
}