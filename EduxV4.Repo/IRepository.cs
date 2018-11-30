using EduxV4.Data;
using System;
using System.Collections.Generic;

namespace EduxV4.Repo
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll(params string[] nav);
        IEnumerable<T> GetMany(Func<T, bool> where, params string[] nav);
        T Get(string id, params string[] nav);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
