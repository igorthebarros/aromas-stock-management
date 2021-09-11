using System.Collections.Generic;

namespace Aromas.App.Interface
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        void Create(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Delete(TEntity obj);
        void Dispose();
    }
}