using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetBoarding.Models;

namespace PetBoarding.Controllers
{
    public class PaymentsController : Controller
    {
        // GET: Payments
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(Guid invoiceId, Guid employeeId, decimal amount, string paymentDate, string paymentMethod, string transactionId, string status)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Models.Payments payment = new Models.Payments
            {
                Invoice = db.Invoices.FirstOrDefault(i => i.InvoiceID == invoiceId),
                ProcessedByEmployee = db.Profiles.OfType<Employees>().FirstOrDefault(e => e.ProfileID == employeeId),
                Amount = amount,
                PaymentDate = DateTime.Parse(paymentDate).ToUniversalTime(),
                PaymentMethod = paymentMethod,
                TransactionID = transactionId,
                Status = status
            };
            if (payment.Invoice == null)
            {
                return Content("Invoice not found.");
            }
            if (payment.ProcessedByEmployee == null)
            {
                return Content("Employee not found.");
            }
            db.Payments.Add(payment);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Content("Error during payment creation: " + ex.Message);
            }
            return Content("Created: " + payment.PaymentID);
        }
        public ActionResult Read(Guid paymentId)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var payment = db.Payments.FirstOrDefault(p => p.PaymentID == paymentId);
            if (payment == null)
            {
                return Content("Payment not found.");
            }
            return View(payment);
        }

        public ActionResult Update(
            Guid paymentId,
            Guid invoiceId,
            Guid employeeId,
            decimal amount,
            string paymentDate,
            string paymentMethod,
            string transactionId,
            string status)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var payment = db.Payments.FirstOrDefault(p => p.PaymentID == paymentId);
            if (payment == null)
            {
                return Content("Payment not found.");
            }
            payment.Invoice = db.Invoices.FirstOrDefault(i => i.InvoiceID == invoiceId);
            if (payment.Invoice == null)
            {
                return Content("Invoice not found");
            }
            payment.ProcessedByEmployee = db.Profiles.OfType<Employees>().FirstOrDefault(e => e.ProfileID == employeeId);
            if (payment.ProcessedByEmployee == null)
            {
                return Content("Employee not found");
            }
            payment.Amount = amount;
            payment.PaymentDate = DateTime.Parse(paymentDate).ToUniversalTime();
            payment.PaymentMethod = paymentMethod;
            payment.TransactionID = transactionId;
            payment.Status = status;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Content("Error during payment update: " + ex.Message);
            }
            return Content("Updated: " + payment.PaymentID);
        }
        public ActionResult Delete(Guid paymentId)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var payment = db.Payments.FirstOrDefault(p => p.PaymentID == paymentId);
            if (payment == null)
            {
                return Content("Payment not found.");
            }
            db.Payments.Remove(payment);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Content("Error during payment deletion: " + ex.Message);
            }
            return Content("Deleted: " + payment.PaymentID);
        }
    }
}