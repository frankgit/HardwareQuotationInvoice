using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService
{
    public class AggregateRoot
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
