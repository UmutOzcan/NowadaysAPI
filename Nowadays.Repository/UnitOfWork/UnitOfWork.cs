using Nowadays.Core.Entities;
using Nowadays.Core.Interfaces.Repositories;
using Nowadays.Core.Interfaces.UnitOfWork;
using Nowadays.Repository.Context;
using Nowadays.Repository.Repositories;

namespace Nowadays.Repository.UnitOfWork;

// Bu pattern, business katmanında yapılan her değişikliğin anlık olarak database e yansıması yerine,
// işlemlerin toplu halde tek bir kanaldan gerçekleşmesini sağlar.
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext context;
    public bool disposed;

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

    public async Task<int> CommitAsync()
    {
        return await context.SaveChangesAsync();
    }

    protected virtual void Clean(bool disposing)
    {
        if (!this.disposed)
            if (disposing)
                context.Dispose();

        this.disposed = true;
    }

    public void Dispose()
    {
        Clean(true);
        GC.SuppressFinalize(this);
    }
}
