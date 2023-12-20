using PetShopMyProject.Connection;
using PetShopMyProject.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShopMyProject.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly PetShopContext _db;

        public RepositoryBase(PetShopContext db)
        {
            _db = db;
        }

        public IUnitOfWork UnitOfWork()
        {
            return _db;
        }

        public void Add(TEntity entity)
        {
            _db.Set<TEntity>().Add(entity);
        }

        public void Dispose()
        {
            _db?.Dispose();
        }

        public TEntity GetById(int id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity entity)
        {
            _db.Remove(entity);
        }
        public List<TEntity> GetAll()
        {
            return _db.Set<TEntity>().ToList();
        }
    }
}
