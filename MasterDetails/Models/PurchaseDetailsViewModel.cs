using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterDetails.Models
{
    public class PurchaseDetailsViewModel
    {
        public Purchase Header { get; set; }
        //public List<PurchaseDetails> Details { get; set; }

        public PurchaseDetails Detail { get; set; }
    }
}