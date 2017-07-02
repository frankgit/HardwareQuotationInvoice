using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService
{
    public class HardwareType: AggregateRoot
    {

        [MaxLength(100)]
        public string Name { get; set; }

        public int OrderPriorityId { get; set; }

        public int CategoryId { get; set; }

        public int ConfigType { get; set; }


    }
}
