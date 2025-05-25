using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTemplate.Models
{
    public class Payments
    {
        [Key]
        [Required]
        public Guid PaymentID { get; set; }
        
        [Required]
        public Guid InvoiceID { get; set; }

        [ForeignKey("InvoiceID")]
        public virtual Invoices Invoice { get; set; }

        [Required]
        public Guid ProcessedByEmployeeID { get; set; }

        [ForeignKey("ProcessedByEmployeeID")]
        public virtual Employees ProcessedByEmployee { get; set; }

        [Column(TypeName ="decimal")]
        public decimal Amount { get; set; }

        DateTime PaymentDate { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(25)]
        public string PaymentMethod { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        public string TransactionID { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Status { get; set; }
    }
}