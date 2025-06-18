﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebAppTemplate.App_Start
{
    public static class EmailServiceCredentials
    {
        public static string EmailSMTPUrl { get; private set; }
        public static string PortNumber { get; private set; }
        public static string EmailSMTPUserName { get; private set; }
        public static string EmailSMTPPasswordHash { get; private set; }
        public static string EmailFromAddress { get; private set; }
        public static string EmailFromName { get; private set; }
        public static string EmailAppName { get; private set; }

        public static void SetCredentials(string emailSMTPUrl, string portNumber, string emailSMTPUserName, string emailSMTPPasswordHash, string emailFromAddress, string emailFromName, string emailAppName)
        {
            EmailSMTPUrl = emailSMTPUrl;
            PortNumber = portNumber;
            EmailSMTPUserName = emailSMTPUserName;
            EmailSMTPPasswordHash = emailSMTPPasswordHash;
            EmailFromAddress = emailFromAddress;
            EmailFromName = emailFromName;
            EmailAppName = emailAppName;
        }

        //Call from global application
        public static void PopulateEmailCredentialsFromAppConfig()
        {
            string emailSMTPURL = ConfigurationManager.AppSettings["emailSMTPURL"].ToString();
            string portNumber = ConfigurationManager.AppSettings["portNumber"].ToString();
            string emailSMTPUserName= ConfigurationManager.AppSettings["emailSMTPUserName"].ToString();
            string emailSMTPPasswordHash = ConfigurationManager.AppSettings["emailSMTPPasswordHash"].ToString();
            string emailFromAddress = ConfigurationManager.AppSettings["emailFromAddress"].ToString();
            string emailFromName = ConfigurationManager.AppSettings["emailFromName"].ToString();
            string emailAppName = ConfigurationManager.AppSettings["emailAppName"].ToString();
            string testValue = System.Configuration.ConfigurationManager.AppSettings["ConfigTestKey"];
            System.Diagnostics.Debug.WriteLine("ConfigTestKey: " + testValue);

            SetCredentials(emailSMTPURL, PortNumber, emailSMTPUserName ,emailSMTPPasswordHash, emailFromAddress, emailFromName, emailAppName);
        }
    }
}
