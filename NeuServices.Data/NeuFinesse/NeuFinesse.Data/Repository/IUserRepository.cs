using System;
using System.Collections.Generic;
using NeuFinesse.Data.Model;

namespace NeuFinesse.Data.Repository
{
    public interface IUserRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(string id);
        TEntity Get(string id);
        void Add(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
        void Delete(TEntity entity);
    }
}
