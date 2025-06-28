using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetBoarding.Models
{
    public class EmergencyContacts
    {
        [Required]
        [Key]
        public Guid EmergencyContactID { get; set; }

        public virtual Pets Pet { get; set; }
        public virtual Employees Employee { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(20)]
        public string Relationship { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        public EmergencyContacts()
        {
            EmergencyContactID = Guid.NewGuid();
        }
    }
}