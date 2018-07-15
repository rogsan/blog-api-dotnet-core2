using System;
using System.Collections.Generic;
using blog_api_dotnet_core2.Models;

namespace blog_api_dotnet_core2.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseModel
    {
        IEnumerable<TEntity> FindAll();

        TEntity Find(Guid id);

        Guid Add(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(Guid id);
    }
}