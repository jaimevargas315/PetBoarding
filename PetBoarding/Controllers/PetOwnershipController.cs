using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetBoarding.Models;

namespace PetBoarding.Controllers
{
    public class PetOwnershipController : Controller
    {
        // GET: PetOwner
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(Guid petId, Guid ownerId)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            PetOwnership petOwnership = new PetOwnership();
            var owner = db.Profiles.OfType<Owners>().FirstOrDefault(o => o.ProfileID == ownerId);
            if (owner == null)
            {
                return Content("Owner not found.");
            }

            var pet = db.Pets.FirstOrDefault(p => p.PetID == petId);
            if (pet == null)
            {
                return Content("Pet not found.");
            }
            petOwnership.Owner = owner;
            petOwnership.Pet = pet;

            db.PetOwnerships.Add(petOwnership);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Content("Error during pet ownership creation: " + ex.Message);
            }

            return Content("Created: " + petOwnership.PetOwnershipID);
        }

        public ActionResult Read(Guid petOwnershipId)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var petOwnership = db.PetOwnerships.FirstOrDefault(po => po.PetOwnershipID == petOwnershipId);
            if (petOwnership == null)
            {
                return Content("Pet ownership not found.");
            }
            return View(petOwnership);
        }

        public ActionResult Update(Guid petOwnershipId, Guid petId, Guid ownerId)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var petOwnership = db.PetOwnerships.FirstOrDefault(po => po.PetOwnershipID == petOwnershipId);
            if (petOwnership == null)
            {
                return Content("Pet ownership not found.");
            }
            var owner = db.Profiles.OfType<Owners>().FirstOrDefault(o => o.ProfileID == ownerId);
            if (owner == null)
            {
                return Content("Owner not found.");
            }
            var pet = db.Pets.FirstOrDefault(p => p.PetID == petId);
            if (pet == null)
            {
                return Content("Pet not found.");
            }
            petOwnership.Owner = owner;
            petOwnership.Pet = pet;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Content("Error during pet ownership update: " + ex.Message);
            }
            return Content("Updated: " + petOwnership.PetOwnershipID);
        }

        public ActionResult Delete(Guid petOwnershipId)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var petOwnership = db.PetOwnerships.FirstOrDefault(po => po.PetOwnershipID == petOwnershipId);
            if (petOwnership == null)
            {
                return Content("Pet ownership not found.");
            }
            db.PetOwnerships.Remove(petOwnership);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Content("Error during pet ownership deletion: " + ex.Message);
            }
            return Content("Deleted: " + petOwnership.PetOwnershipID);
        }

    }
}