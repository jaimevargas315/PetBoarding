using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppTemplate.Models
{
    public class ContactUsSubmissions
    {
        [Key]
        [Required]
        public Guid ContactUsSubmissionId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }

        public ContactUsSubmissions()
        {
            ContactUsSubmissionId = Guid.NewGuid();
        }
    }
}