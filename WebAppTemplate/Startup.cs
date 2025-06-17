using Microsoft.Owin;
using Owin;
using System;

[assembly: OwinStartupAttribute(typeof(WebAppTemplate.Startup))]
namespace WebAppTemplate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            string configPath = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            System.Diagnostics.Debug.WriteLine("Loaded config file: " + configPath);

            ConfigureAuth(app);
        }
    }
}
