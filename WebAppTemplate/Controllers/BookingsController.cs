using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppTemplate.Models;

namespace WebAppTemplate.Controllers
{
    public class BookingsController : Controller
    {
        // GET: Bookings
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(
            Guid petId,
            string status,
            decimal price,
            string startTime,
            string endTime
            )

        {
            ApplicationDbContext db = new ApplicationDbContext();
            Bookings booking = new Bookings();
            Pets pet = db.Pets.FirstOrDefault(p => p.PetID == petId);
            if (pet == null)
            {
                return Content("Pet not found.");
            }
            booking.Pet = pet;
            booking.Status = status;
            booking.Price = price;
            booking.StartTime = DateTime.Parse(startTime).ToUniversalTime();
            booking.EndTime = DateTime.Parse(endTime).ToUniversalTime();

            db.Bookings.Add(booking);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Content("Error during database creation: " + ex.Message);
            }
            return Content("Created: " + booking.BookingID);
        }
        public ActionResult Read(Guid id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Bookings booking = db.Bookings.FirstOrDefault(b => b.BookingID == id);
            
            if (booking == null)
            {
                return Content("Booking not found.");
            }
            else
            {
                return Content($"Booking found: {booking.BookingID}, {booking.Pet}, {booking.Status}, {booking.Price}, {booking.CreatedDate}, {booking.StartTime},  {booking.EndTime}, {booking.LastUpdated}");
            }

        }
        public ActionResult Update(
            Guid bookingId,
            Guid petId,
            string status,
            decimal price,
            string startTime,
            string endTime
            )
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Bookings booking = db.Bookings.FirstOrDefault(b => b.BookingID == bookingId);
            if (booking == null)
            {
                return Content("Booking not found.");
            }
            Pets pet = db.Pets.FirstOrDefault(p => p.PetID == petId);
            if (pet == null)
            {
                return Content("Pet not found.");
            }
            booking.Pet = pet;
            booking.Status = status;
            booking.Price = price;
            booking.StartTime = DateTime.Parse(startTime).ToUniversalTime();
            booking.EndTime = DateTime.Parse(endTime).ToUniversalTime();
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Content("Error during database update: " + ex.Message);
            }
            return Content("Updated: " + booking.BookingID);
        }
        public ActionResult Delete(Guid bookingId)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Bookings booking = db.Bookings.FirstOrDefault(b => b.BookingID == bookingId);
            if (booking == null)
            {
                return Content("Booking not found.");
            }
            db.Bookings.Remove(booking);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Content("Error during database deletion: " + ex.Message);
            }
            return Content("Deleted: " + booking.BookingID);
        }
    }
}