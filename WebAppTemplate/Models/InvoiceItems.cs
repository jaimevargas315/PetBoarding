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
        public virtual Invoices Invoice { get; set; }

        [Required]
        public virtual Bookings Booking { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public InvoiceItems()
        {
            InvoiceItemID = Guid.NewGuid();
        }

    }
}