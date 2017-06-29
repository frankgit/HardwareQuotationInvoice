using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SQLite;

namespace HardwareQuotationInvoice.Models
{
    public class ComputerCategory
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
        
        public int Order { get; set; }

    }
}