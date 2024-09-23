using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApplication1.Data;
namespace WebApplication1.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DemoContext context;

        public GenericRepository(DemoContext _context)
        {
            context = _context;
        }   
        public void Add(T entity)
        {
            context.Add(entity);
        }

        public List<T> Find(Expression<Func<T, bool>> match, string[] Includes)
        {
            IQueryable<T> query = context.Set<T>();
            if (Includes != null)
                foreach (var Include in Includes)
                    query.Include(Include);
            return query.Where(match).ToList();
        }

        public List<T> Find(Expression<Func<T, bool>> match)
        {
            IQueryable<T> query = context.Set<T>();
            return query.Where(match).ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }
        List<T> IGenericRepository<T>.GetAll()
        {
            return context.Set<T>().ToList();
        }
        T IGenericRepository<T>.GetById(int id)
        {
            return context.Set<T>().Find(id);
        }
        List<T> IGenericRepository<T>.Join(string[] Includes)
        {
            IQueryable<T> query = context.Set<T>();
            if(Includes != null)
                foreach(var Include in Includes)
                    query = query.Include(Include);
            return query.ToList();
        }
    }
}
