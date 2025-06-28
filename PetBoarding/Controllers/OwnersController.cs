using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetBoarding.Models;

namespace PetBoarding.Controllers
{
    public class OwnersController : Controller
    {
        // GET: Owner
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(
            Guid petId,
            string firstName,
            string lastName,
            string phone,
            string email,
            string address1,
            string address2,
            string city,
            string state,
            string zip,
            string preferredContactMethod
            )
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Owners owner = new Owners();
            owner.FirstName = firstName;
            owner.LastName = lastName;
            owner.Phone = phone;
            owner.Email = email;
            owner.Address1 = address1;
            owner.Address2 = address2;
            owner.City = city;
            owner.State = state;
            owner.Zip = zip;
            owner.PreferredContactMethod = preferredContactMethod;

            db.Profiles.Add(owner);

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Content("Error during owner creation: " + ex.Message);

            }
            return Content("Created: " + owner.ProfileID);
        }
        public ActionResult Read(Guid id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Owners owner = db.Profiles.OfType<Owners>().FirstOrDefault(o => o.ProfileID == id);
            if (owner == null)
            {
                return Content("Owner not found.");
            }
            else
            {
                return View(owner);
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
            string preferredContactMethod)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Owners owner = db.Profiles.OfType<Owners>().FirstOrDefault(o => o.ProfileID == id);
            if (owner == null)
            {
                return Content("Owner not found.");
            }
            owner.FirstName = firstName;
            owner.LastName = lastName;
            owner.Phone = phone;
            owner.Email = email;
            owner.Address1 = address1;
            owner.Address2 = address2;
            owner.City = city;
            owner.State = state;
            owner.Zip = zip;
            owner.PreferredContactMethod = preferredContactMethod;
            owner.LastUpdated = DateTime.UtcNow;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Content("Error during owner update: " + ex.Message);
            }
            return Content("Updated: " + owner.ProfileID);
        }
        public ActionResult Delete(Guid id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Owners owner = db.Profiles.OfType<Owners>().FirstOrDefault(o => o.ProfileID == id);
            if (owner == null)
            {
                return Content("Owner not found.");
            }
            db.Profiles.Remove(owner);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Content("Error during owner deletion: " + ex.Message);
            }
            return Content("Deleted: " + owner.ProfileID);
        }
    }
}