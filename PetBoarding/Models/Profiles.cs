using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PetBoarding.Models
{
    public class Profiles
    {
        [Key]
        [Required]
        public Guid ProfileID { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Address1 { get; set; }

        [MaxLength(15)]
        public string Address2 { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [StringLength(2)]
        public string State { get; set; }

        [StringLength(5)]
        public string Zip { get; set; }

        public Profiles()
        {
            ProfileID = Guid.NewGuid();
        }

    }
}