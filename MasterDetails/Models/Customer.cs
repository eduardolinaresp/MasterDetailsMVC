using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDetails.Models
{
    public class Customer
    {
        [Key]
        [Display(Name= "Codigo Cliente")]
        public int CustomerId { get; set; }
        [Display(Name = "Nombre Compañia")]
        [StringLength(30,ErrorMessage = "El Campo {0} debe estar entre {2} y {1} caracteres", MinimumLength =3)]
        [Required(ErrorMessage ="El campo {0} es obligatirio")]
        public string CompanyName { get; set; }
        public string ContacName { get; set; }
        public virtual ICollection<Order> Orders  { get; set; }


}
}
