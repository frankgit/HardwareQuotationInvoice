using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService
{
    public class HardwareQuotaService:IHardwareQuotaService
    {
        private IRepository<ComputerCategory> _repository;
        public HardwareQuotaService(IRepository<ComputerCategory> repository)
        {
            _repository = repository;
        }
        public void AddNewComputerType(ComputerCategory computerCategory)
        {
            _repository.Insert(computerCategory);
        }

        public IEnumerable<ComputerCategory>  GetAllComputerCategory()
        {
            return _repository.Entitles;
        }
    }
}
