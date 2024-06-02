using Microsoft.EntityFrameworkCore;
using Nowadays.Core.Interfaces.Repositories;
using Nowadays.Repository.Context;
using System.Linq.Expressions;

namespace Nowadays.Repository.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class // Repository Pattern simplifies CRUD operations
{
    private readonly AppDbContext context;
    private DbSet<T> table;
    public GenericRepository(AppDbContext context)
    {
        this.context = context;
        table = context.Set<T>();
    }

    public async Task InsertAsync(T entity)
    {
        entity.GetType().GetProperty("CreatedDate").SetValue(entity, DateTime.Now); // we set the date property while creating the property.
        entity.GetType().GetProperty("IsActive").SetValue(entity, true); // could be improved and used
        await table.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task Delete(T entity)
    {
        entity.GetType().GetProperty("IsActive").SetValue(entity, false); 
        context.Remove(entity);
        await context.SaveChangesAsync();
    }

    public IQueryable<T> GetAll()
    {
        return table.AsNoTracking().AsQueryable(); // since there will only be reading, tracking will be turned off.
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await table.Where(entity => EF.Property<int>(entity, "Id").Equals(id)).SingleOrDefaultAsync();
    }

    public async Task<T> GetWithWhereAsync(Expression<Func<T, bool>> filter = null)
    {
        return await table.FirstOrDefaultAsync(filter);
    }

    public async Task<int> UpdateAsync(T entity)
    {
        entity.GetType().GetProperty("ModifiedDate")?.SetValue(entity, DateTime.Now);
        table.Update(entity);
        return await context.SaveChangesAsync();
    }
}
