using E_Commerce.Domin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domin.Contract
{
    public interface IUnitOfWork
    {
        IGenericRepository<TEntity, TKey> GetGenericRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;

        Task<int> CommitAsync(); 
    }
}
