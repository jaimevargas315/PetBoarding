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
        public virtual Pets Pet { get; set; }

        [Required]
        public virtual Owners Owner { get; set; }

        public PetOwnership()
        {
            PetOwnershipID = Guid.NewGuid();
        }
    }
}