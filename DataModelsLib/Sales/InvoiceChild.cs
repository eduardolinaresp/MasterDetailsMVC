using DataModels.Stocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModels.Sales
{
    public class InvoiceChild
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Item")]
        [Required]
        public int ItemId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [ForeignKey("Invoice")]
        [Required]
        public int InvoiceId { get; set; }

        public InvoiceMaster Invoice { get; set; }

        public Item Item { get; set; }

    }
}
