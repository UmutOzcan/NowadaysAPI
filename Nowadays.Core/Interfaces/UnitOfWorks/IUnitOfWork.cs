using Nowadays.Core.Entities;
using Nowadays.Core.Interfaces.Repositories;

namespace Nowadays.Core.Interfaces.UnitOfWorks;

public interface IUnitOfWork : IDisposable // UnitOfWork Pattern ensures that transactions are carried out collectively through a single channel, instead of every change being instantly reflected in the database.
{
    IGenericRepository<Company> CompanyRepository { get; }
    IGenericRepository<Employee> EmployeeRepository { get; }
    IGenericRepository<Issue> IssueRepository { get; }
    IGenericRepository<Project> ProjectRepository { get; }
    Task<int> CommitAsync();
}
