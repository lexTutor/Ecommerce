using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeManagement.Core.RepositoryAbstractions
{
    public interface IGenericRepository<TEntity>  where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<bool> Add(TEntity model);
        Task<TEntity> GetById(object Id);
        Task<bool> Modify(TEntity entity);
        Task<bool> DeleteById(object Id);
    }
}
