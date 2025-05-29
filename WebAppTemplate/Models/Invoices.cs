using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppTemplate.Models
{
    public class Invoices
    {   
        [Key]
        [Required]
        public Guid InvoiceID { get; set; }

        [Required]
        public virtual Owners Owner { get; set; }

        public virtual List<Payments> Payments { get; set; }

        public virtual List<InvoiceItems> InvoiceItem { get; set; }

        public DateTime Issuedate { get; set; }
        public DateTime DueDate { get; set; }

        public decimal TotalAmount { get; set; }

        public Invoices()
        {
            InvoiceID = Guid.NewGuid();
        }
    }
}