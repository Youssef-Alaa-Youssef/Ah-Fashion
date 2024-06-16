using ShareEdu.Factory.BLL.Interfaces;

namespace ShareEdu.Factory.BLL.InterFaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync();
    }
}
