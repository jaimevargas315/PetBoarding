using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetBoarding.Models
{
    public class Payments
    {
        [Key]
        [Required]
        public Guid PaymentID { get; set; }

        [Required]
        public virtual Invoices Invoice { get; set; }

        [Required]
        public virtual Employees ProcessedByEmployee { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        [MaxLength(25)]
        public string PaymentMethod { get; set; }

        [MaxLength(100)]
        public string TransactionID { get; set; }

        [MaxLength(50)]
        public string Status { get; set; }

        public Payments()
        {
            PaymentID = Guid.NewGuid();
        }
    }
}