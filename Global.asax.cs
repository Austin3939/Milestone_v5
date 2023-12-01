using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Inscript_v5
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            string connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__Inscriptv4Entities");
            if (!string.IsNullOrEmpty(connectionString))
            {
            var connectionStringsSection = ConfigurationManager.ConnectionStrings["Inscriptv4Entities"];
            connectionStringsSection.ConnectionString = connectionString;
            }
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
