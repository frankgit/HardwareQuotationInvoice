using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService
{
    public interface IHardwareQuotaService: IService
    {
        void AddNewComputerType(ComputerCategory computerCategory);

        IEnumerable<ComputerCategory> GetAllComputerCategory();
    }
}
