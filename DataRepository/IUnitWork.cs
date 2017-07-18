using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessService;
using SQLite;

namespace DataRepository
{
    public interface IUnitWork<TEntity> where TEntity:AggregateRoot
    {
        List<TEntity> EntityCollection { get; set; }

        string Connection { get; }

        bool IsCommitted { get; set; }

        void Rollback();

        void RegisterNew(TEntity entity);

        void RegisterUpdate(TEntity entity);

        void RegisterDelete(TEntity entity);

        void RegisterDelete(object Id);

        void Commit();
        
             
    }
}
