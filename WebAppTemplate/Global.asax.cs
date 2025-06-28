using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebAppTemplate.App_Start;
using WebAppTemplate.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace WebAppTemplate
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            EmailServiceCredentials.PopulateEmailCredentialsFromAppConfig();

            CreateRoles();
        }

        private void CreateRoles()
        {
            using (var context = new ApplicationDbContext())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                if (!roleManager.RoleExists("Owner"))
                {
                    var role = new IdentityRole();
                    role.Name = "Owner";
                    IdentityResult roleResult = roleManager.Create(role);
                    // Handle roleResult.Succeeded or errors if creation fails
                    if (!roleResult.Succeeded)
                    {
                        // Log or handle error: Failed to create Customer role
                        System.Diagnostics.Trace.TraceError("Failed to create owner role: " + string.Join("; ", roleResult.Errors));
                    }
                }

                if (!roleManager.RoleExists("Employee"))
                {
                    var role = new IdentityRole();
                    role.Name = "Employee";
                    IdentityResult roleResult = roleManager.Create(role);
                    // Handle roleResult.Succeeded or errors if creation fails
                    if (!roleResult.Succeeded)
                    {
                        // Log or handle error: Failed to create Employee role
                        System.Diagnostics.Trace.TraceError("Failed to create Employee role: " + string.Join("; ", roleResult.Errors));
                    }
                }
                // Add other roles here if needed
            }
        }

    }
}
