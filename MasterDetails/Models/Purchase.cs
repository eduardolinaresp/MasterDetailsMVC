using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterDetails.Models
{
    public class Purchase
    {

        public long  Id { get; set; }

        public string CustomerName { get; set; }

        public string CustomerContactNo { get; set; }

        public string Description { get; set; }

        public DateTime PurchaseDate { get; set; }


        public virtual ICollection<PurchaseDetails> PurchaseDetailses { get; set; }


    }
}