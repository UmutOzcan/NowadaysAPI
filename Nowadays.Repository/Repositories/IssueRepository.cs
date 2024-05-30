using Nowadays.Core.Entities;
using Nowadays.Repository.Context;

namespace Nowadays.Repository.Repositories;

public class IssueRepository(AppDbContext context) : GenericRepository<Issue>(context)
{
}
