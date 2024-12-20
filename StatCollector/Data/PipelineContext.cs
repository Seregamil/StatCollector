using Microsoft.EntityFrameworkCore;

namespace StatCollector.Data;

public class PipelineContext : DbContext
{
    public PipelineContext() {}
    
    public PipelineContext(DbContextOptions<PipelineContext> options)
        : base(options)
    {
    }
    
    public DbSet<Caller> Callers { get; set; } = null!;
    public DbSet<Job> Jobs { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PipelineContext).Assembly);
    }
}