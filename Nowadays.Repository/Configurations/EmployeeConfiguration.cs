using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nowadays.Core.Entities;

namespace Nowadays.Repository.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee> // Configuration files are used to build database data.
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {

        Employee employee1 = new()
        {
            Id = 1,
            FirstName = "Umut",
            LastName = "Ozcan",
            ProjectId = 1,
            CreatedDate = DateTime.Now,
            NationalIdentity = 1234567890,
            DateOfBirth = 2000,
            IsActive = true,
        };

        Employee employee2 = new()
        {
            Id = 2,
            FirstName = "Ahmet",
            LastName = "Yılmaz",
            ProjectId = 2,
            CreatedDate = DateTime.Now,
            NationalIdentity = 1234567899,
            DateOfBirth = 1995,
            IsActive = true,
        };

        builder.HasData(employee1,employee2);
    }
}
