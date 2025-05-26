using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppTemplate.Models
{
    public class InvoiceItems
    {
        [Key]
        [Required]
        public Guid InvoiceItemID { get; set; }

        [Required]
        public Invoices Invoice { get; set; }

        [Required]
        public Bookings Booking { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(200)]
        public string Description { get; set; }

        [Column(TypeName = "decimal")]
        public decimal Price { get; set; }

        public InvoiceItems()
        {
            InvoiceItemID = Guid.NewGuid();
        }

    }
}