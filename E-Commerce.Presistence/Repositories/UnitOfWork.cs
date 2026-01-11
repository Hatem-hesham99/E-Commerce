using E_Commerce.Domin.Contract;
using E_Commerce.Domin.Entities;
using E_Commerce.Presistence.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _dbContext;

        private readonly Dictionary<Type, object> _repositories;
        public UnitOfWork(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public IGenericRepository<TEntity, TKey> GetGenericRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var entityType = typeof(TEntity);
         //   if (_repositories.TryGetValue(entityType , out var Repositories)) return (IGenericRepository<TEntity, TKey>)Repositories;

            if(_repositories.ContainsKey(entityType)) return (IGenericRepository<TEntity, TKey>) _repositories[entityType];
            var NewRepositories = new GenericRepository<TEntity, TKey>(_dbContext);

            _repositories.Add(entityType, NewRepositories);
            return NewRepositories;
        }
    }
}
