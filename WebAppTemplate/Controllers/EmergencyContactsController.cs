using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppTemplate.Models;

namespace WebAppTemplate.Controllers
{
    public class EmergencyContactsController : Controller
    {
        // GET: EmergencyContacts
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(
            Guid? petId,
            Guid? employeeId,
            string firstName,
            string lastName,
            string relationship,
            string phone,
            string email
            )
        {
            ApplicationDbContext db = new ApplicationDbContext();
            EmergencyContacts emergencyContact = new EmergencyContacts();
            emergencyContact.FirstName = firstName;
            emergencyContact.LastName = lastName;
            emergencyContact.Relationship = relationship;
            emergencyContact.Phone = phone;
            emergencyContact.Email = email;
            if (petId != null)
            {
                Pets Pet = db.Pets.FirstOrDefault(p => p.PetID == petId);
                if (Pet == null)
                {
                    return Content("Pet not found.");
                }
                else emergencyContact.Pet = Pet;
            }
            if (employeeId != null)
            {
                Employees Employee = db.Profiles.OfType<Employees>().FirstOrDefault(e => e.ProfileID == employeeId);
                if (Employee == null)
                {
                    return Content("Employee not found.");
                }
                else emergencyContact.Employee = Employee;
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Content("Error during contact creation: " + ex.Message);
            }
            return Content("Created: " + emergencyContact.EmergencyContactID);
        }
        public ActionResult Read(Guid id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            EmergencyContacts emergencyContact = db.EmergencyContacts.FirstOrDefault(ec => ec.EmergencyContactID == id);

            if (emergencyContact == null)
            {
                return Content("Emergency contact not found.");
            }
            else
            {
                return View(emergencyContact);
            }
        }

        public ActionResult Update(
                Guid id,
                Guid? petId,
                Guid? employeeId,
                string firstName,
                string lastName,
                string relationship,
                string phone,
                string email
                )
        {
            ApplicationDbContext db = new ApplicationDbContext();
            EmergencyContacts emergencyContact = db.EmergencyContacts.FirstOrDefault(ec => ec.EmergencyContactID == id);

            if (petId != null)
            {
                Pets Pet = db.Pets.FirstOrDefault(p => p.PetID == petId);
                if (Pet == null)
                {
                    return Content("Pet not found.");
                }
                else emergencyContact.Pet = Pet;
            }
            if (employeeId != null)
            {
                Employees Employee = db.Profiles.OfType<Employees>().FirstOrDefault(e => e.ProfileID == employeeId);
                if (Employee == null)
                {
                    return Content("Employee not found.");
                }
                else emergencyContact.Employee = Employee;
            }
            if (emergencyContact == null)
            {
                return Content("Emergency contact not found.");
            }

            emergencyContact.FirstName = firstName;
            emergencyContact.LastName = lastName;
            emergencyContact.Relationship = relationship;
            emergencyContact.Phone = phone;
            emergencyContact.Email = email;
            try
            {
                db.SaveChanges();
                return Content("Updated: " + emergencyContact.EmergencyContactID);
            }
            catch (Exception ex)
            {
                return Content("Error during update: " + ex.Message);
            }
        }
        public ActionResult Delete(Guid id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            EmergencyContacts emergencyContact = db.EmergencyContacts.FirstOrDefault(ec => ec.EmergencyContactID == id);
            if (emergencyContact == null)
            {
                return Content("Emergency contact not found.");
            }
            db.EmergencyContacts.Remove(emergencyContact);
            try
            {
                db.SaveChanges();
                return Content("Deleted: " + emergencyContact.EmergencyContactID);
            }
            catch (Exception ex)
            {
                return Content("Error during deletion: " + ex.Message);
            }
        }

    }
}