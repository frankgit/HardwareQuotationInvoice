using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataRepository;

namespace HardwareQuotationInvoice
{
    public class StructureMapBootrstrapper
    {
        public static void Bootstrap(IContainer container)
        {
            container.Configure(x =>
            {
                x.AddRegistry<HareWareRegistry>();
                x.AddRegistry<RepositoryRegistry>();
            });
        }
    }
}