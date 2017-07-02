using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService
{
    public class Hardware: AggregateRoot
    {

        [MaxLength(100)]
        public string Name { get; set; }

        public int OrderPriorityId { get; set; }

        public int HardwareTypeId { get; set; }

        public double Price { get; set; }


    }
}
