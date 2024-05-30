using Nowadays.Core.Entities;
using Nowadays.Repository.Context;

namespace Nowadays.Repository.Repositories;

public class ProjectRepository(AppDbContext context) : GenericRepository<Project>(context)
{
}
