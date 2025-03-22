
using Data;
using Interfaces;

namespace Repository;
public class Repository<T> : IRepository<T> where T : class
{
    private ClsAppNtierContext _context;

    public Repository(ClsAppNtierContext context)
    {
        _context = context;
    }
    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
       // _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
       // _context.SaveChanges();
    }

    public void Delete(int id)
    {
        // var entity= _context.Set<T>().Find(id);
        //_context.Set<T>().Remove(entity);
        //_context.SaveChanges();

        var entity = GetById(id);
        Delete(entity);

    }

    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public T GetById(int id)
    {
       return _context.Set<T>().Find(id);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
       // _context.SaveChanges();
    }
}
