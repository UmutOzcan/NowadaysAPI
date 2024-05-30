using Nowadays.Core.Entities;
using Nowadays.Repository.Context;

namespace Nowadays.Repository.Repositories;

public class CompanyRepository(AppDbContext context) : GenericRepository<Company>(context)
{
}
