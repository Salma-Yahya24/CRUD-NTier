using Data;
using Entities;
using Interfaces;

namespace Repository;
public class UnitofWork : IUnitofWork
{
    private ClsAppNtierContext _context;

    public UnitofWork(ClsAppNtierContext context)
    {
        _context = context;
        
        Products = new Repository<Product>(_context);
        Categories = new Repository<Category>(_context);
    }

    public IRepository<Product> Products { get; }

    public IRepository<Category> Categories { get; }

    public void Dispose()
    {
        _context.Dispose();
    }

    public int Save()
    {
     return   _context.SaveChanges();
    }
}
