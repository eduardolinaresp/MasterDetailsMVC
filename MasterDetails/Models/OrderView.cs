using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterDetails.Models
{
    public class OrderView
    {
        public CustomerOrder Customer { get; set; }
        public ProductOrder Titles { get; set; }
        public List<ProductOrder> Products { get; set; }


    }
}