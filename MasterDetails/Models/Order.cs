using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MasterDetails.Models
{
    public class Order
    {
        [Key]
        [Display(Name = "Numero Orden")]
        public int OrderId { get; set; }
        [DisplayFormat(DataFormatString ="{0:dd/mm/yyyy}" ,ApplyFormatInEditMode =true)]
        [Display(Name ="Fecha Orden")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        [Display(Name = "Codigo Cliente")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}