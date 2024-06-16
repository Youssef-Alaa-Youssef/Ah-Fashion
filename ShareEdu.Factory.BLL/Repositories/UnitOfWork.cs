using ShareEdu.Factory.BLL.Repositories;
using ShareEdu.Factory.BLL.Interfaces;
using ShareEdu.Factory.DAL.Data;
using ShareEdu.Factory.BLL.InterFaces; 

namespace ShareEdu.Factory.BLL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FactoryDbContext _context;
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(FactoryDbContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories.ContainsKey(typeof(TEntity)))
            {
                return _repositories[typeof(TEntity)] as IRepository<TEntity>;
            }

            var repository = new Repository<TEntity>(_context);
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
