﻿using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessService;

namespace DataRepository
{
    public class RepositoryRegistry : Registry
    {
        public  RepositoryRegistry()
        {
            For<IRepository<ComputerCategory>>()
                .Use<ComputerRepository>();

            For(typeof(IUnitWork<>))
                .Use(typeof(UnitWork<>));

        }
    }
}
