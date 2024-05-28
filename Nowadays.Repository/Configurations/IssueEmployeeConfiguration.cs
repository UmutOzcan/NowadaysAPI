using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nowadays.Core.Entities;

namespace Nowadays.Repository.Configurations;

public class IssueEmployeeConfiguration : IEntityTypeConfiguration<IssueEmployee>
{
    public void Configure(EntityTypeBuilder<IssueEmployee> builder)
    {
        builder.HasKey(x => new { x.IssueId, x.EmployeeId });

        builder.HasOne(i => i.Issue)
            .WithMany(ie => ie.IssueEmployees)
            .HasForeignKey(i => i.IssueId)
            .OnDelete(DeleteBehavior.Cascade); // bagli yerler silinir


        builder.HasOne(e => e.Employee)
            .WithMany(ie => ie.IssueEmployees)
            .HasForeignKey(e => e.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict); // bagli yerler null yapilir
    }
}
