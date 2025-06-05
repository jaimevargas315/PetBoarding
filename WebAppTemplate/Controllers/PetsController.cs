using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppTemplate.Models;

namespace WebAppTemplate.Controllers
{
    public class PetsController : Controller
    {
        // GET: Pets
        public ActionResult Index()
        {
            return View();
        }
        // Bookings are optional so won't be included here
        public ActionResult Create(
            string name,
            string species,
            string breed,
            string sex,
            string birthday,
            string color,
            bool neutered,
            string allergies,
            string medNotes,
            string needs,
            Guid emergencyContactId)
        {
            // #1 Create an instance of ApplicationDbContext to interact with the database
            ApplicationDbContext db = new ApplicationDbContext();
            var emergencyContact = db.EmergencyContacts.FirstOrDefault(x => x.EmergencyContactID == emergencyContactId);
            if (emergencyContact == null)
            {
                return Content("Emergency Contact not found.");
            }

            // #2 Create a new pet object
            Pets Pet = new Pets();
            Pet.Name = name;
            Pet.Species = species;
            Pet.Breed = breed;
            Pet.Sex = sex;
            Pet.DateOfBirth = DateTime.Parse(birthday);
            Pet.Color = color;
            Pet.IsNeuteredOrSpayed = neutered;
            Pet.Allergies = allergies;
            Pet.MedicalNotes = medNotes;
            Pet.SpecialNeeds = needs;
            Pet.EmergencyContacts = new List<EmergencyContacts> { emergencyContact }; 

            // #3 Add the new pet to the database context
            db.Pets.Add(Pet);

            // #4 Save changes to the database           
            try
            {
                db.SaveChanges();               
            }
            catch (Exception ex)
            {
                Content("Error during pet creation: " + ex);// Handle any exceptions that may occur
            }
            return Content("Created: " + Pet.PetID );
        }
        public ActionResult Read(Guid id)
        {
            // #1 Create an instance of ApplicationDbContext to interact with the database
            ApplicationDbContext db = new ApplicationDbContext();

            // 2 query the database and save to our object
            Pets Pet = db.Pets.FirstOrDefault(x => x.PetID == id);

            // 3 validate and return
            if (Pet == null)
            {
                return Content("Pet not found.");
            }
            else
            {
                return Content($"Pet found: {Pet.Name}, {Pet.Species}, {Pet.Breed}, {Pet.Sex} , {Pet.DateOfBirth}, {Pet.Color}, {Pet.IsNeuteredOrSpayed}, {Pet.Allergies}, {Pet.MedicalNotes}, {Pet.SpecialNeeds}");
            }
        }
        // Bookings in optional so won't be included here
        public ActionResult Update(
            Guid id,
            string name,
            string species,
            string breed,
            string sex,
            string birthday,
            string color,
            bool neutered,
            string allergies,
            string medNotes,
            string needs,
            Guid emergencyContactId
            )
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Pets Pet = db.Pets.FirstOrDefault(x => x.PetID == id);
            if (Pet == null)
            {
                return Content("Pet not found.");
            }
            var emergencyContact = db.EmergencyContacts.FirstOrDefault(x => x.EmergencyContactID == emergencyContactId);
            if (emergencyContact == null)
            {
                return Content("Emergency Contact not found.");
            }
            Pet.Name = name;
            Pet.Species = species;
            Pet.Breed = breed;
            Pet.Sex = sex;
            Pet.DateOfBirth = DateTime.Parse(birthday);
            Pet.Color = color;
            Pet.IsNeuteredOrSpayed = neutered;
            Pet.Allergies = allergies;
            Pet.MedicalNotes = medNotes;
            Pet.SpecialNeeds = needs;
            if (Pet.EmergencyContacts == null)
            {
                Pet.EmergencyContacts = new List<EmergencyContacts>();                
            }
            Pet.EmergencyContacts.Add(emergencyContact);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Content("Error during database update: " + ex.Message); // Handle any exceptions that may occur
            }
            return Content("Updated: " +Pet.PetID);
        }

        public ActionResult Delete(Guid id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Pets Pet = db.Pets.FirstOrDefault(x => x.PetID == id);
            if (Pet == null)
            {
                return Content("Pet not found.");
            }
            if (Pet != null)
            {
                List<EmergencyContacts> emergencyContacts = Pet.EmergencyContacts.ToList();

                foreach (var contact in emergencyContacts)
                {
                    if(contact.Employee == null) // if no employee is associated with the contact
                    db.EmergencyContacts.Remove(contact); // Remove associated emergency contacts
                }
                db.Pets.Remove(Pet);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return Content("Error during database deletion: " + ex.Message); // Handle any exceptions that may occur
                }
            }
            return Content("Deleted: " + id);

        }
    }
}