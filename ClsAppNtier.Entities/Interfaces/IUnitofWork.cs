using Entities;

namespace Interfaces;

public interface IUnitofWork : IDisposable
{
    IRepository<Category> Categories { get; }
    IRepository<Product> Products { get; }

    int Save();
}
