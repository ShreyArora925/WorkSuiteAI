using System;
using System.Collections.Generic;
using System.Text;

namespace WorkSuiteAI.Infrastructure.Data
{
    public interface IRepository<T>
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}
