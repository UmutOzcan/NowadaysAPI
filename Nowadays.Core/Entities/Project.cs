namespace Nowadays.Core.Entities;

public class Project : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public int CompanyId { get; set; }
    public Company Company { get; set; }

    public ICollection<Employee> Employees { get; set; }
    public ICollection<Issue> Issues { get; set; }
}
