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
        public IUnitWork<TEntity> _unitWorker;

        public string TableName;
        public BaseRepository(IUnitWork<TEntity> unitWorker) 
        {
            _unitWorker = unitWorker;
        }

        public IEnumerable<TEntity> Entitles
        {
            get
            {
                return GetAllData();
            }
        }

        public virtual IEnumerable<TEntity> GetAllData()
        {
            return null;
        }

        public void Delete(TEntity entity)
        {
            _unitWorker.RegisterNew(entity);
            _unitWorker.Commit();
        }

        public void Delete(IEnumerable<TEntity> Entities)
        {
            foreach (var entity in Entities)
            {
                _unitWorker.RegisterDelete(entity);
            }
            _unitWorker.Commit();           
        }

        public void Delete(object Id)
        {
            _unitWorker.RegisterDelete(Id);
            _unitWorker.Commit();
        }

        public TEntity GetByKey(object key)
        {
            throw new NotImplementedException();
        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _unitWorker.RegisterNew(entity);
            }
            _unitWorker.Commit();
        }

        public void Insert(TEntity entity)
        {
            _unitWorker.RegisterNew(entity);
            _unitWorker.Commit();
        }

        public void Update(TEntity entity)
        {
            _unitWorker.RegisterUpdate(entity);
            _unitWorker.Commit();
        }
    }
}
