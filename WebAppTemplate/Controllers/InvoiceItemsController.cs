using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppTemplate.Models;

namespace WebAppTemplate.Controllers
{
    public class InvoiceItemsController : Controller
    {
        // GET: InvoiceItems
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(
        Guid invoiceItemId,
        Guid InvoiceId,
        Guid bookingId,
        string description,
        decimal price
        )
        {
            ApplicationDbContext db = new ApplicationDbContext();

            InvoiceItems invoiceItem = new InvoiceItems
            {
                InvoiceItemID = invoiceItemId,
                Invoice = db.Invoices.FirstOrDefault(i => i.InvoiceID == InvoiceId),
                Booking = db.Bookings.FirstOrDefault(b => b.BookingID == bookingId),
                Description = description,
                Price = price
            };
            if (invoiceItem.Invoice == null || invoiceItem.Booking == null)
            {
                return Content("Invoice or Booking not found.");
            }
            db.InvoiceItems.Add(invoiceItem);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Content("Error during invoice item creation: " + ex.Message);
            }
            return Content("Created: " + invoiceItem.InvoiceItemID);
        }
        public ActionResult Read(Guid id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            InvoiceItems invoiceItem = db.InvoiceItems.FirstOrDefault(ii => ii.InvoiceItemID == id);
            if (invoiceItem == null)
            {
                return Content("Invoice item not found.");
            }
            return View(invoiceItem);
        }

        public ActionResult Update(
            Guid id,
            string description,
            decimal price)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            InvoiceItems invoiceItem = db.InvoiceItems.FirstOrDefault(ii => ii.InvoiceItemID == id);
            if (invoiceItem == null)
            {
                return Content("Invoice item not found.");
            }
            invoiceItem.Description = description;
            invoiceItem.Price = price;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Content("Error during invoice item update: " + ex.Message);
            }
            return Content("Updated: " + invoiceItem.InvoiceItemID);
        }
        public ActionResult Delete(Guid id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            InvoiceItems invoiceItem = db.InvoiceItems.FirstOrDefault(ii => ii.InvoiceItemID == id);
            if (invoiceItem == null)
            {
                return Content("Invoice item not found.");
            }
            db.InvoiceItems.Remove(invoiceItem);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Content("Error during invoice item deletion: " + ex.Message);
            }
            return Content("Deleted: " + invoiceItem.InvoiceItemID);

        }
    }
}