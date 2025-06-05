using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppTemplate.Models;
using WebAppTemplate.ViewModels;
namespace WebAppTemplate.Controllers
{
    public class ContactUsController : Controller
    {
        // GET: ContactUs
        public ActionResult Index()
        {
            ContactUsSubmissionVM contactUsSubmissionVM = new ContactUsSubmissionVM();
            return View(contactUsSubmissionVM);
        }

        public ActionResult Submitted()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Submit(ContactUsSubmissionVM contactUsSubmissionVM)
        {
            if (string.IsNullOrEmpty(contactUsSubmissionVM.FirstName))
            {
                return Content("First Name is required.");
            }
            if (string.IsNullOrEmpty(contactUsSubmissionVM.LastName))
            {
                return Content("Last Name is required.");
            }
            if (string.IsNullOrEmpty(contactUsSubmissionVM.Email) || !contactUsSubmissionVM.Email.Contains("@"))
            {
                return Content("A valid Email is required.");
            }
            if (string.IsNullOrEmpty(contactUsSubmissionVM.PhoneNumber) || contactUsSubmissionVM.PhoneNumber.Length < 10)
            {
                return Content("A valid Phone Number is required.");
            }
            if (string.IsNullOrEmpty(contactUsSubmissionVM.Message))
            {
                return Content("Message cannot be empty.");
            }
            ApplicationDbContext db = new ApplicationDbContext();
            ContactUsSubmissions contactUsSubmission = new ContactUsSubmissions
            {
                FirstName = contactUsSubmissionVM.FirstName,
                LastName = contactUsSubmissionVM.LastName,
                Email = contactUsSubmissionVM.Email,
                PhoneNumber = contactUsSubmissionVM.PhoneNumber,
                Message = contactUsSubmissionVM.Message
            };

            try
            {
                db.contactUsSubmissions.Add(contactUsSubmission);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Content("An error occurred while adding your submission: " + ex.Message);
            }
            return RedirectToAction("Submitted", "ContactUs");

        }
    }
}