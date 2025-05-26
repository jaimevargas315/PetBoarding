using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTemplate.Models
{
    public class Employees: Profiles
    {
        public List<Payments> Payment { get; set; }

        [Column(TypeName ="varchar")]
        [MaxLength(20)]
        public string Position { get; set; }

        DateTime HireDate { get; set; }

        [Column(TypeName ="decimal")]
        public decimal Wage { get; set; }

        [Column(TypeName ="bit")]
        public bool Active { get; set; }

        DateTime? TerminationDate { get; set; }

        [Column(TypeName ="varchar")]
        Guid EmergencyContactID { get; set; }

        [Required]
        public List<EmergencyContacts> EmergencyContact { get; set; }
    }
}