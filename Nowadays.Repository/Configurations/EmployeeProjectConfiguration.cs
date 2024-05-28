using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nowadays.Core.Entities;

namespace Nowadays.Repository.Configurations;

public class EmployeeProjectConfiguration : IEntityTypeConfiguration<EmployeeProject>
{
    public void Configure(EntityTypeBuilder<EmployeeProject> builder)
    {
        builder.HasKey(x => new { x.EmployeeId, x.ProjectId });

        builder.HasOne(e => e.Employee)
            .WithMany(ep => ep.EmployeeProjects)
            .HasForeignKey(e => e.EmployeeId)
            .OnDelete(DeleteBehavior.NoAction);


        builder.HasOne(p => p.Project)
            .WithMany(ep => ep.EmployeeProjects)
            .HasForeignKey(p => p.ProjectId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
