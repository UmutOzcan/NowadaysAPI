using Nowadays.Core.Entities;
using Nowadays.Repository.Context;

namespace Nowadays.Repository.Repositories;

public class EmployeeRepository(AppDbContext context) : GenericRepository<Employee>(context)
{
}
