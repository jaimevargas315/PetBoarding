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
        public Guid OwnerID { get; set; }

        [ForeignKey("OwnerID")]
        public virtual Owners Owner { get; set; }

        DateTime Issuedate { get; set; }
        DateTime DueDate { get; set; }
        public virtual ICollection<InvoiceItems> InvoiceItems { get; set; }

        [Column(TypeName = "decimal")]
        public decimal TotalAmount { get; set; }
    }
}