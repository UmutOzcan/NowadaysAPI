﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nowadays.Core.Entities;

namespace Nowadays.Repository.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {

        Company company1 = new()
        {
            Id = 1,
            Name = "PortalGroup",
            CreatedDate = DateTime.Now,
            IsActive = true,

        };

        builder.HasData(company1);
    }
}