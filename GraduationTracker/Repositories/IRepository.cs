using System;
using System.Collections.Generic;

namespace GraduationTracker.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);
    }
}