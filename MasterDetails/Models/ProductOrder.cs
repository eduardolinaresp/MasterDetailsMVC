using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterDetails.Models
{
    public class ProductOrder :Product
    {

        public int Quantity { get; set; }
        public decimal Partial { get { return UnitPrice * Quantity; } }

    }
}