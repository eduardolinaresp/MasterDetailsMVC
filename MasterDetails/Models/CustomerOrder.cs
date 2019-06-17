using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MasterDetails.Models
{
    public class CustomerOrder :Customer
    {
        [Display(Name ="Fecha orden")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
    }
}