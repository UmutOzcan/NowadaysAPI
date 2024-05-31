namespace Nowadays.Core.Entities;

public class Employee : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public long NationalIdentity { get; set; }
    public int DateOfBirth { get; set; }

    public ICollection<Project> Projects { get; set; }
    public ICollection<Issue> Issues { get; set; }
}
