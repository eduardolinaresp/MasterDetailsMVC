using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MasterDetails.Models
{
    public class Product
    {
        [Key]
        [Display(Name = "Codigo Producto")]
        public int ProductId { get; set; }
        [Display(Name = "Nombre Producto")]
        public string ProductName {get; set; }
        [DisplayFormat(DataFormatString ="{0:C2}",ApplyFormatInEditMode =false)]
        [Display(Name = "Precio Unitario")]
        public decimal UnitPrice { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }


    }
}