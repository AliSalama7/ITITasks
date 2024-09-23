using System.Linq.Expressions;
namespace WebApplication1.Repository
{
    public interface IGenericRepository<T> where T : class
    {
       void Add(T entity);
       List<T> GetAll();
       T GetById(int id);
       void Save();
        List<T> Join(string[] Includes);
        List<T>Find(Expression<Func<T,bool>> match,string[] Includes);
        List<T> Find(Expression<Func<T, bool>> match);
    }
}
