using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService
{
    public class ComputerCategory:AggregateRoot
    {

        [MaxLength(100)]
        public string Name { get; set; }

        [PrimaryKey]
        public int OrderPriorityId { get; set; }


    }
}
