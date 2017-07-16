using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessService;
using SQLite;
using System.Configuration;

namespace DataRepository
{
    public class UnitWork<TEntity>:IUnitWork<TEntity> where TEntity: AggregateRoot
    {
        public UnitWork()
        {
            _unitCollection = new List<TEntity>();
        }

        private  EntityRegisterType _registerType;

        public EntityRegisterType RegisterType
        {
            get
            {
                return _registerType;
            }
            set { _registerType = value; }
        }
        public void Commit()
        {
            if(IsCommitted)
            {
                return;
            }

            try
            {
                using (var db = new SQLiteConnection(Connection))
                {
                    switch (RegisterType)
                    {
                        case EntityRegisterType.Insert:
                            db.InsertAll(_unitCollection,true);
                            break;
                        case EntityRegisterType.Update:
                            db.UpdateAll(_unitCollection,true);
                            break;
                        case EntityRegisterType.Delete:
                            db.BeginTransaction();
                            foreach (var unit in _unitCollection)
                            {
                                db.Delete(unit);
                            }
                            db.Commit();
                            break;
                    }
                }
                IsCommitted = true;
                _unitCollection.Clear();
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }


        public void RegisterNew(TEntity entity)
        {
            _unitCollection.Add(entity);
            IsCommitted = false;
            _registerType = EntityRegisterType.Insert;
        }

        public void RegisterUpdate(TEntity entity)
        {
            _unitCollection.Add(entity);
            IsCommitted = false;
            _registerType = EntityRegisterType.Update;
        }

        public void RegisterDelete(TEntity entity)
        {
            _unitCollection.Add(entity);
            IsCommitted = false;
            _registerType = EntityRegisterType.Delete;
        }

        public void RegisterDelete(object Id)
        {
            var entityRoot = new AggregateRoot();
            entityRoot.Id = int.Parse(Id.ToString());
            _unitCollection.Add(entityRoot as TEntity);
            IsCommitted = false;
            _registerType = EntityRegisterType.Delete;
        }


        #region Implement IUnitWork
        private List<TEntity> _unitCollection;
        private bool _isCommited;

        public string Connection
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + "\\App_Data\\" + ConfigurationManager.AppSettings["DataFilePath"];
            }
        }

        public List<TEntity> EntityCollection
        {
            get
            {
                return _unitCollection;
            }

            set
            {
                _unitCollection = value;
            }
        }

        public bool IsCommitted
        {
            get
            {
                return _isCommited;
            }

            set
            {
                _isCommited = value;
            }
        }

        public void Rollback()
        {
            _isCommited = false;
        }


        #endregion

        
        #region IDisposable接口
        public void Dispose()
        {
            if (!_isCommited)
            {
                Commit();
            }
            Dispose();
        }

       
        #endregion


    }
}
