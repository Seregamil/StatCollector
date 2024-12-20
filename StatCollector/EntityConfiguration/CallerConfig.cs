using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceMan.BaseLibrary.Extensions;
using StatCollector.Data;

namespace StatCollector.EntityConfiguration;

public class CallerConfig: IEntityTypeConfiguration<Caller>
{
    public void Configure(EntityTypeBuilder<Caller> builder)
    {
        builder.ToTable("users");

        builder.HasKey(x => x.Id);
        
        builder.HasIndex(x => x.Login);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasMaxLength(256)
            .HasColumnName("name")
            .IsRequired();
        
        builder.Property(x => x.Login)
            .HasMaxLength(64)
            .HasColumnName("login")
            .IsRequired();
        
        builder.Property(x => x.Email)
            .HasMaxLength(256)
            .HasColumnName("email")
            .IsRequired();

        builder.HasMany(x => x.ExecutedJobs)
            .WithOne(x => x.Caller)
            .HasForeignKey(x => x.CallerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
