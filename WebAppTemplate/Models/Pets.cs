using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTemplate.Models
{
    public class Pets
    {
        [Key]
        [Required]
        public Guid PetID { get; set; }

        public List<Bookings> Booking { get; set; }
        public List<PetOwnership> PetOwnership { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(30)]
        public string Species { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(30)]
        public string Breed { get; set; }

        [Column(TypeName = "char")]
        [StringLength(1)]
        public string Sex { get; set; }

        DateTime DateOfBirth { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(30)]
        public string Color { get; set; }

        [Column(TypeName ="bit")]
        public bool IsNeuteredOrSpayed { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(500)]
        public string Allergies { get; set; }

        [Column(TypeName = "text")]
        [MaxLength(1000)]
        public string MedicalNotes { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(500)]
        public string SpecialNeeds { get; set; }

        public List<EmergencyContacts> EmergencyContact { get; set; }

        public Pets()
        {
            PetID = Guid.NewGuid();
        }
    }
}   