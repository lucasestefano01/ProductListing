using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsDDD.Application.Interface
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        List<TEntity> Get();

        TEntity Get(string id);

        TEntity Create(TEntity obj);

        void Update(string id, TEntity obj);

        void Remove(TEntity obj);

        void Remove(string id);
    }
}
