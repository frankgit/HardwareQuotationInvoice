using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessService;

namespace DataRepository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : AggregateRoot
    {
        private IUnitWork<TEntity> UnitWorker;
        public BaseRepository(IUnitWork<TEntity> DbUnitWorker) 
        {
        }

        public IQueryable<TEntity> Entitles
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Delete(TEntity entity)
        {
            UnitWorker.RegisterNew(entity);
            UnitWorker.Commit();
        }

        public void Delete(IEnumerable<TEntity> Entities)
        {
            foreach (var entity in Entities)
            {
                UnitWorker.RegisterDelete(entity);
            }
            UnitWorker.Commit();           
        }

        public void Delete(object Id)
        {
            UnitWorker.RegisterDelete(Id);
            UnitWorker.Commit();
        }

        public TEntity GetByKey(object key)
        {
            throw new NotImplementedException();
        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
