using System.Collections.Generic;

namespace Aromas.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Create(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Delete(TEntity obj);
        void Dispose();
    }
}