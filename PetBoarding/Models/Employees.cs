﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetBoarding.Models
{
    public class Employees : Profiles
    {
        public virtual List<Payments> Payment { get; set; }

        [MaxLength(20)]
        public string Position { get; set; }

        public DateTime HireDate { get; set; }

        public decimal Wage { get; set; }

        public bool Active { get; set; }

        public DateTime? TerminationDate { get; set; }

        public virtual List<EmergencyContacts> EmergencyContact { get; set; }

        public Employees()
        {
            HireDate = DateTime.Now;
            Active = true;
        }
    }
}