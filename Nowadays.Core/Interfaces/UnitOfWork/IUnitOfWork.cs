using Nowadays.Core.Entities;
using Nowadays.Core.Interfaces.Repositories;

namespace Nowadays.Core.Interfaces.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Company> CompanyRepository { get; }
    IGenericRepository<Employee> EmployeeRepository { get; }
    IGenericRepository<Issue> IssueRepository { get; }
    IGenericRepository<Project> ProjectRepository { get; }
    Task<int> CommitAsync();
}
