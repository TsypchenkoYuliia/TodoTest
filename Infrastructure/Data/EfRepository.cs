using Ardalis.Specification.EntityFrameworkCore;
using SharedCore.Interfaces;

namespace Infrastructure.Data
{
    public class EfRepository<T> : RepositoryBase<T>, IRepository<T> where T : class
    {
        public EfRepository(TodoDbContext dbContext) : base(dbContext)
        {
        }
    }
}
