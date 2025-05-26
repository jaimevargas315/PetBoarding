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
        public Owners Owner { get; set; }

        public List<Payments> Payment { get; set; }

        [Required]
        public List<InvoiceItems> InvoiceItem { get; set; }

        DateTime Issuedate { get; set; }
        DateTime DueDate { get; set; }

        [Column(TypeName = "decimal")]
        public decimal TotalAmount { get; set; }

        public Invoices()
        {
            InvoiceID = Guid.NewGuid();
        }
    }
}