using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTemplate.Models
{
    public class EmergencyContacts
    {
        [Required]
        [Key]
        public Guid EmergencyContactID { get; set; }

        public Pets Pet { get; set; }
        public Employees Employee { get; set; }

        [Column(TypeName="varchar")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(20)]
        public string Relationship { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(20)]
        public string Phone { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Email { get; set; }

        public EmergencyContacts()
        {
            EmergencyContactID = Guid.NewGuid();
        }
    }
}