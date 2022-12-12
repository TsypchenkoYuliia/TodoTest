using Ardalis.Specification;

namespace SharedCore.Interfaces
{
    public interface IRepository<T> : IRepositoryBase<T> where T : class
    {
    }
}
