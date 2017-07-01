using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessService;

namespace DataRepository
{
    public class ComputerRepository : BaseRepository<ComputerCategory>
    {
        public ComputerRepository(IUnitWork<ComputerCategory> DbUnitWorker) : base(DbUnitWorker)
        {
        }
    }
}
