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
        [Index(IsUnique = true)]
        public Guid BookingID { get; set; }
        [ForeignKey("BookingID")]
        public virtual Bookings Booking { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public Guid InvoiceID { get; set; }
        [ForeignKey("InvoiceID")]
        public virtual Invoices Invoice { get; set; }


        [Column(TypeName = "varchar")]
        [MaxLength(200)]
        public string Description { get; set; }

        [Column(TypeName = "decimal")]
        public decimal Price { get; set; }

    }
}