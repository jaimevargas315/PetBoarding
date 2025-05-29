using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppTemplate.Models;

namespace WebAppTemplate.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(
            Guid ownerId,
            string dueDate
            )
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Invoices invoice = new Invoices();
            invoice.Owner = db.Profiles.OfType<Owners>().FirstOrDefault(o => o.ProfileID == ownerId);
            if (invoice.Owner == null)
            {
                return Content("Owner not found.");
            }
            invoice.Payments = new List<Payments>();
            invoice.InvoiceItem = new List<InvoiceItems>();
            invoice.Issuedate = DateTime.Now.ToUniversalTime();

            db.Invoices.Add(invoice);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Content("Error during invoice creation: " + ex.Message);
            }
            return Content("Created: " + invoice.InvoiceID);
        }
        public ActionResult Read(Guid id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Invoices invoice = db.Invoices.FirstOrDefault(i => i.InvoiceID == id);
            if (invoice == null)
            {
                return Content("Invoice not found.");
            }
            return View(invoice);
        }
        public ActionResult Update(
            Guid id,
            Guid ownerId,
            string dueDate,
            decimal totalAmount)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Invoices invoice = db.Invoices.FirstOrDefault(i => i.InvoiceID == id);
            if (invoice == null)
            {
                return Content("Invoice not found.");
            }
            Owners owner = db.Profiles.OfType<Owners>().FirstOrDefault(o => o.ProfileID == ownerId);
            if (owner == null)
            {
                return Content("Owner not found.");
            }
            invoice.Owner = owner;
            invoice.DueDate = DateTime.Parse(dueDate).ToUniversalTime();
            invoice.TotalAmount = totalAmount;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Content("Error during invoice update: " + ex.Message);

            }
            return Content("Updated: " + invoice.InvoiceID);
        }
        public ActionResult Delete(Guid id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Invoices invoice = db.Invoices.FirstOrDefault(i => i.InvoiceID == id);
            if (invoice == null)
            {
                return Content("Invoice not found.");
            }
            db.Invoices.Remove(invoice);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Content("Error during invoice deletion: " + ex.Message);
            }
            return Content("Deleted: " + invoice.InvoiceID);
        }
    }
}