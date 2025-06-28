using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetBoarding.Models;

namespace PetBoarding.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(
            string firstName,
            string lastName,
            string phone,
            string email,
            string address1,
            string address2,
            string city,
            string state,
            string zip,
            string position,
            string hireDate,
            decimal wage,
            Guid emergencyContactId,
            bool active = true

            )
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Employees employee = new Employees();
            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.Phone = phone;
            employee.Email = email;
            employee.Address1 = address1;
            employee.Address2 = address2;
            employee.City = city;
            employee.State = state;
            employee.Zip = zip;
            employee.Position = position;
            employee.HireDate = DateTime.Parse(hireDate).ToUniversalTime();
            employee.Wage = wage;
            employee.Active = active;

            var emergencyContact = db.EmergencyContacts.FirstOrDefault(x => x.EmergencyContactID == emergencyContactId);
            if (emergencyContact == null)
            {
                return Content("Emergency Contact not found.");
            }
            db.Profiles.Add(employee);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Content("Error during employee creation: " + ex.Message);
            }

            return Content("Created: " + employee.ProfileID);
        }
        public ActionResult Read(Guid id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Employees employee = db.Profiles.OfType<Employees>().FirstOrDefault(e => e.ProfileID == id);
            if (employee == null)
            {
                return Content("Employee not found.");
            }
            else
            {
                return View(employee);
            }
        }
        public ActionResult Update(
            Guid id,
            string firstName,
            string lastName,
            string phone,
            string email,
            string address1,
            string address2,
            string city,
            string state,
            string zip,
            string position,
            string hireDate,
            decimal wage,
            bool active,
            string terminationDate,
            Guid emergencyContactId
        )
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Employees employee = db.Profiles.OfType<Employees>().FirstOrDefault(e => e.ProfileID == id);
            if (employee == null)
            {
                return Content("Employee not found.");
            }

            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.Phone = phone;
            employee.Email = email;
            employee.Address1 = address1;
            employee.Address2 = address2;
            employee.City = city;
            employee.State = state;
            employee.Zip = zip;
            employee.Position = position;
            employee.HireDate = DateTime.Parse(hireDate).ToUniversalTime();
            employee.Wage = wage;
            employee.Active = active;
            if (terminationDate == null || terminationDate == "")
            {
                employee.TerminationDate = null;
            }
            else
                employee.TerminationDate = DateTime.Parse(terminationDate).ToUniversalTime();

            var emergencyContact = db.EmergencyContacts.FirstOrDefault(x => x.EmergencyContactID == emergencyContactId);

            if (employee.EmergencyContact == null)
            {
                employee.EmergencyContact = new List<EmergencyContacts>();
            }

            employee.EmergencyContact.Add(emergencyContact);

            if (emergencyContact == null)
            {
                return Content("Emergency Contact not found.");
            }

            try
            {
                db.SaveChanges();
                return Content("Updated: " + employee.ProfileID);
            }
            catch (Exception ex)
            {
                return Content("Error during update employee: " + ex.Message);
            }

        }
        public ActionResult Delete(Guid id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Employees employee = db.Profiles.OfType<Employees>().FirstOrDefault(e => e.ProfileID == id);
            EmergencyContacts emergencyContact = db.EmergencyContacts.FirstOrDefault(x => x.Employee.ProfileID == id);

            if (employee == null)
            {
                return Content("Employee not found.");
            }
            if (emergencyContact == null)
            {
                return Content("Emergency Contact not found.");
            }
            emergencyContact.Employee = null;
            if(emergencyContact.Pet == null)
            {
                db.EmergencyContacts.Remove(emergencyContact);
            }         
            db.Profiles.Remove(employee);
            try
            {
                db.SaveChanges();
                return Content("Deleted: " + employee.ProfileID);
            }
            catch (Exception ex)
            {
                return Content("Error during deletion: " + ex.Message);
            }
        }
    }
}