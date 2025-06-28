using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetBoarding.Models
{
    public class Bookings
    {
        [Key][Required]
        public Guid BookingID { get; set; }

        [Required]
        public virtual Pets Pet { get; set; }
        
        [MaxLength(50)]
        public string Status { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime LastUpdated { get; set; }
        
        public Bookings()
        {
            BookingID = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
            LastUpdated = DateTime.UtcNow;

        }
    }
}