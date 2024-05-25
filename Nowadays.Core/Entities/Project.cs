namespace Nowadays.Core.Entities;

public class Project : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }

    public int CompanyId { get; set; }
    public Company Company { get; set; } // OneToMany

    public ICollection<EmployeeProject> EmployeeProjects { get; set; } // ManyToMany
    public ICollection<Issue> Issues { get; set; } // OneToMany
}
