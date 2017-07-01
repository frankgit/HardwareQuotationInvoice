using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HardwareQuotationInvoice
{
    public class StructureMapBootrstrapper
    {
        public static void Bootstrap(IContainer container)
        {
            container.Configure(x =>
            {
                x.Scan(a =>
                {
                    a.AssembliesFromApplicationBaseDirectory();
                    a.LookForRegistries();
                });
            });
        }
    }
}