using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTemplate.Models
{
    public class Owners : Profiles
    {

        public List<Invoices> Invoice { get; set; }

        [Required]
        public List<PetOwnership> PetOwnership { get; set; }

        [Column(TypeName = "bit")]
        public bool Registered { get; set; }

        public DateTime RegistrationDate { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(20)]
        public string PreferredContactMethod { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdated { get; set; }

        public Owners()
        {
            CreatedDate = DateTime.Now;
            LastUpdated = DateTime.Now;
        }
    }
}