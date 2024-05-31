using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nowadays.Core.Entities;

namespace Nowadays.Repository.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        Project project1 = new()
        {
            Id = 1,
            Name = "MusteriTakip",
            Description = "Musteri Takip Projesi",
            CompanyId = 1,
            IsActive = true,
            CreatedDate = DateTime.Now,
        };

        Project project2 = new()
        {
            Id = 2,
            Name = "Oyun Projesi",
            Description = "Peak Oyun Projesi",
            CompanyId = 1,
            IsActive = true,
            CreatedDate = DateTime.Now,
        };

        builder.HasData(project1);
    }
}
