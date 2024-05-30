using Microsoft.EntityFrameworkCore;
using Nowadays.Core.Interfaces.Repositories;
using Nowadays.Repository.Context;
using System.Linq.Expressions;

namespace Nowadays.Repository.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly AppDbContext context;
    private DbSet<T> table;
    public GenericRepository(AppDbContext context)
    {
        this.context = context;
        table = context.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        table.GetType().GetProperty("CreatedDate").SetValue(entity, DateTime.Now);
        await table.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task Delete(T entity)
    {
        context.Remove(entity);
        await context.SaveChangesAsync();
    }

    public IQueryable<T> GetAll()
    {
        return table.AsNoTracking().AsQueryable(); // sadece okuma olacagindan tracking i kapatiriz
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await table.Where(entity => EF.Property<int>(entity, "Id").Equals(id)).SingleOrDefaultAsync();
    }

    //public async Task<IEnumerable<T>> GetWhereListAsync(Expression<Func<T, bool>> filter)
    //{
    //    return await table.Where(filter).ToListAsync();
    //}

    public async Task<T> GetWithWhereAsync(Expression<Func<T, bool>> filter = null)
    {
        return await table.FirstOrDefaultAsync(filter);
    }

    public async Task<int> UpdateAsync(T entity)
    {
        entity.GetType().GetProperty("UpdatedDate").SetValue(entity, DateTime.Now);
        table.Update(entity);
        return await context.SaveChangesAsync();
    }
}
