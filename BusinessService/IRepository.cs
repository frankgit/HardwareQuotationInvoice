using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessService;

namespace BusinessService
{
    public interface IRepository<TEntity> where TEntity:AggregateRoot
    {
        IQueryable<TEntity> Entitles { get; }

        void Insert(TEntity entity);
        void Insert(IEnumerable<TEntity> entities);

        void Delete(object id);

        void Delete(TEntity entity);

        void Delete(IEnumerable<TEntity> Entities);

        void Update(TEntity entity);

        TEntity GetByKey(object key);



    }
}
