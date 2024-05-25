namespace Nowadays.Core.Entities;

public class Company : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Project> Projects { get; set; }  // OneToMany
    public ICollection<Employee> Employees { get; set; }  // OneToMany
}
