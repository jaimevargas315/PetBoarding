using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebAppTemplate.Models
{
    public class User
    {
        [Key]
        [Required]
        public Guid UserID { get; set; }

        [Column (TypeName ="varchar")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(20)]
        public string Phone { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Email { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Address1 { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(15)]
        public string Address2 { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string City { get; set; }

        [Column(TypeName = "char")]
        [StringLength(2)]
        public string State { get; set; }

        [Column(TypeName = "char")]
        [StringLength(5)]
        public string Zip { get; set; }

    }
}