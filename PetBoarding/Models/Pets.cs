using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetBoarding.Models
{
    public class Pets
    {
        [Key]
        [Required]
        public Guid PetID { get; set; }

        public virtual List<Bookings> Booking { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(30)]
        public string Species { get; set; }

        [MaxLength(30)]
        public string Breed { get; set; }

        [StringLength(1)]
        public string Sex { get; set; }

        public DateTime DateOfBirth { get; set; }

        [MaxLength(30)]
        public string Color { get; set; }

        public bool IsNeuteredOrSpayed { get; set; }

        [MaxLength(500)]
        public string Allergies { get; set; }

        [MaxLength(1000)]
        public string MedicalNotes { get; set; }

        [MaxLength(500)]
        public string SpecialNeeds { get; set; }

        [Required]
        public virtual List<EmergencyContacts> EmergencyContacts { get; set; }

        public Pets()
        {
            PetID = Guid.NewGuid();
        }
    }
}   