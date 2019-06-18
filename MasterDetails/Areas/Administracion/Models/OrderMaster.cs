using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MasterDetails.Areas.Administracion.Models
{
    public class OrderMaster
    {
        public OrderMaster()
        {
            this.OrderDetails1 = new HashSet<OrderDetail1>();
        }

        [Key]
        public int OrderID { get; set; }
        public string OrderNo { get; set; }
        public string Description { get; set; }
        public System.DateTime OrderDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail1> OrderDetails1 { get; set; }

    }
}