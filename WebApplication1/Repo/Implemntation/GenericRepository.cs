using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Repo.Implemntation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDBContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public ICollection<T> GetAll() =>  _dbSet.ToList();
        public T GetById(int id) =>  _dbSet.Find(id);
        public void Create(T entity) => _dbSet.Add(entity);
        public void Update(T entity) => _dbSet.Update(entity);
        public void Delete(T entity) => _dbSet.Remove(entity);

       
    }
}
