﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using PetBoarding.Models;
using PetBoarding.App_Start;

namespace PetBoarding
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            System.Diagnostics.Debug.WriteLine("SendAsync called");
            return SendEmailAsync(message.Destination, message.Subject, message.Body);
        }

        public async Task SendEmailAsync(string destination, string subject, string body)
        {
            try
            {
                MailMessage mailMessage = EmailService.GenerateMailMessage(destination, subject, body);
                System.Diagnostics.Debug.WriteLine("Attempting to send email...");
                await EmailService.GetSmtpClient().SendMailAsync(mailMessage);
                System.Diagnostics.Debug.WriteLine("Email send initiated.");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Email send error: " + ex.ToString());
                throw;
            }
        }

        public static SmtpClient GetSmtpClient()
        {
            SmtpClient smtpClient = new SmtpClient(EmailServiceCredentials.EmailSMTPUrl);
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(EmailServiceCredentials.EmailSMTPUserName, EmailServiceCredentials.EmailSMTPPasswordHash);

            return smtpClient;
        }

        public static MailMessage GenerateMailMessage(string destination, string subject, string body)
        {
            MailMessage mailMessage = new MailMessage(new MailAddress(EmailServiceCredentials.EmailFromAddress, EmailServiceCredentials.EmailFromName), new MailAddress(destination));
            mailMessage.Subject = EmailServiceCredentials.EmailAppName + " - " + subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;

            return mailMessage;
        }


    }



    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context) 
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.

            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            System.Diagnostics.Debug.WriteLine("EmailService constructor called");

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = 
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}
