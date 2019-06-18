using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MasterDetails.Areas.Administracion.Models
{
    public class OrderDetail1
    {
        [Key]
        public int OrderDetailsID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public int Quantity { get; set; }

        public virtual OrderMaster OrderMaster { get; set; }

    }
}