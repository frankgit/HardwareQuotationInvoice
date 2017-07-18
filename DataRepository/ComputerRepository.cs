using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessService;
using SQLite;

namespace DataRepository
{
    public class ComputerRepository : BaseRepository<ComputerCategory>
    {
        public ComputerRepository(IUnitWork<ComputerCategory> DbUnitWorker) : base(DbUnitWorker)
        {
            
        }

        public override IEnumerable<ComputerCategory> GetAllData()
        {           
            var conn = new SQLiteConnection(_unitWorker.Connection);
            var query = conn.Table<ComputerCategory>();
            return query;
        }


    }
}
