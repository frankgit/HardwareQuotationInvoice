using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HardwareQuotationInvoice.Models
{


    public class ComputerCatogryView
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int OrderPriorityId { get; set; }
    }

    public class HardwareTypeView
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int OrderPriorityId { get; set; }

        public int CategoryId { get; set; }

        public int ConfigType { get; set; }


    }


    public class HardwareView
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int OrderPriorityId { get; set; }

        public int HardwareTypeId { get; set; }

        public double Price { get; set; }


    }

}