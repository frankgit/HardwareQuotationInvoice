using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {

            For<IRepository<ComputerCategory>>()
                .Use<ComputerRepository>();

            //For(typeof(IUnitWork<>))
            //    .Use(typeof(UnitWork<>));

        }
    }
}
