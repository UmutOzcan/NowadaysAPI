namespace Nowadays.Core.Entities;

public class Employee : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public long NationalIdentity { get; set; }
    public int DateOfBirth { get; set; }


    public int CompanyId { get; set; }
    public Company Company { get; set; } // OneToMany
    public ICollection<IssueEmployee> IssueEmployees { get; set; } // ManyToMany
    public ICollection<EmployeeProject> EmployeeProjects { get; set; } // ManyToMany
}
