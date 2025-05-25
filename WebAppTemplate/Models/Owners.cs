using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTemplate.Models
{
    public class Owners : User
    {
        [Column(TypeName = "bit")]
        public bool Registered { get; set; }

        public DateTime RegistrationDate { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(20)]
        public string PreferredContactMethod { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}