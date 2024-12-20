using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceMan.BaseLibrary.Extensions;
using StatCollector.Data;

namespace StatCollector.EntityConfiguration;

public class JobConfig: IEntityTypeConfiguration<Job>
{
    public void Configure(EntityTypeBuilder<Job> builder)
    {
        builder.ToTable("pipelines");

        builder.HasKey(x => x.Id);
        
        builder.HasIndex(x => x.Name);
        builder.HasIndex(x => x.CallerId);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasMaxLength(128)
            .HasColumnName("name")
            .IsRequired();
        
        builder.Property(x => x.BuildId)
            .HasColumnName("build_id")
            .IsRequired();

        builder.Property(x => x.Url)
            .HasMaxLength(256)
            .HasColumnName("url")
            .IsRequired();
        
        builder.Property(x => x.Stages)
            .HasColumnName("stages")
            .HasColumnType("jsonb")
            .IsRequired()
            .HasConversion(
                v => JsonSerializer.Serialize(v, Json.GetOptions()),
                v => JsonSerializer.Deserialize<IEnumerable<object>>(v, Json.GetOptions())
                     ?? new List<object>());
        
        builder.Property(x => x.Status)
            .HasMaxLength(32)
            .HasColumnName("status")
            .IsRequired();

        builder.Property(x => x.CallerId)
            .HasColumnName("caller_id")
            .IsRequired();
            
        builder.HasOne(x => x.Caller)
            .WithMany(x => x.ExecutedJobs)
            .HasForeignKey(x => x.CallerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
