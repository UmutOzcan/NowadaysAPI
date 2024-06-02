using Nowadays.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Nowadays.Repository.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) // database configurations and creations
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Issue> Issues { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // Instead of adding the Configurations files one by one, we imported them as an assembly.
    }
}
