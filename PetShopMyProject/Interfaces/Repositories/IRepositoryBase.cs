using PetShopMyProject.Connection;
using System.Collections.Generic;

namespace PetShopMyProject.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        TEntity GetById(int id);

        IUnitOfWork UnitOfWork();

        void Remove(TEntity entity);

        List<TEntity> GetAll();
    }
}