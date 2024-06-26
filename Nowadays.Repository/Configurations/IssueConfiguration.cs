﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nowadays.Core.Entities;

namespace Nowadays.Repository.Configurations;

public class IssueConfiguration : IEntityTypeConfiguration<Issue> // Configuration files are used to build database data.
{
    public void Configure(EntityTypeBuilder<Issue> builder)
    {
        Issue issue1 = new()
        {
            Id = 1,
            Name = "Fix Bug",
            Description = "Check for bugs",
            ProjectId = 1,
            EmployeeId = 1,
            CreatedDate = DateTime.Now,
            IsActive = true,
        };

        builder.HasData(issue1);
    }
}
