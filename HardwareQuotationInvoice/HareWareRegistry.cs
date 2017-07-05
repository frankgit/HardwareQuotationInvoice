using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessService;
using DataRepository;

namespace HardwareQuotationInvoice
{
    public class HareWareRegistry : Registry
    {
        public HareWareRegistry()
        {
            For<IHardwareQuotaService>()
                .Use<HardwareQuotaService>();



        }
    }
}