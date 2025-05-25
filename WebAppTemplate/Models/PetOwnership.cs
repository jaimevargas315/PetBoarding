using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTemplate.Models
{
    public class PetOwnership
    {
        [Required]
        [Key]
        public Guid PetOwnershipID { get; set; }

        [Required]
        public Guid UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        [Required]
        public Guid PetID { get; set; }

        [ForeignKey("PetID")]
        public virtual Pets Pet { get; set; }
    }
}