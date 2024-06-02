using Nowadays.Core.Entities;
using Nowadays.Core.Interfaces.Repositories;
using Nowadays.Core.Interfaces.UnitOfWorks;
using Nowadays.Repository.Context;
using Nowadays.Repository.Repositories;

namespace Nowadays.Repository.UnitOfWorks;

// UnitOfWork Pattern ensures that transactions are carried out collectively through a single channel, instead of every change being instantly reflected in the database.
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext context;
    public bool disposed; // a flag to indicate whether the object has been disposed

    public IGenericRepository<Company> CompanyRepository { get; private set; }
    public IGenericRepository<Employee> EmployeeRepository { get; private set; }
    public IGenericRepository<Issue> IssueRepository { get; private set; }
    public IGenericRepository<Project> ProjectRepository { get; private set; }

    public UnitOfWork(AppDbContext context)
    {
        this.context = context;
        CompanyRepository = new CompanyRepository(context);
        EmployeeRepository = new EmployeeRepository(context);
        IssueRepository = new IssueRepository(context);
        ProjectRepository = new ProjectRepository(context);
    }

    public async Task<int> CommitAsync() // method to save changes to the database asynchronously
    {
        return await context.SaveChangesAsync();
    }

    protected virtual void Clean(bool disposing) // method to clean up resources
    {
        if (!this.disposed) // check if the object has already been disposed
            if (disposing) // dispose the context if disposing is true
                context.Dispose();

        this.disposed = true;
    }

    public void Dispose()
    {
        Clean(true);
        GC.SuppressFinalize(this); // suppress finalization to optimize garbage collection
    }
}
