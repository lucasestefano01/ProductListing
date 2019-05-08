using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsDDD.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity: class
    {
        List<TEntity> Get();

        TEntity Get(string id);

        TEntity Create(TEntity obj);

        void Update(string id, TEntity obj);

        void Remove(TEntity obj);

        void Remove(string id);
    }
}
