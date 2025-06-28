using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetBoarding.Models
{
    public class Owners : Profiles
    {
        [MaxLength(20)]
        public string PreferredContactMethod { get; set; }

        public virtual List<Invoices> Invoice { get; set; }

        public virtual List<PetOwnership> PetOwnership { get; set; }


        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdated { get; set; }

        public Owners()
        {
            CreatedDate = DateTime.UtcNow;
            LastUpdated = DateTime.UtcNow;
        }
    }
}