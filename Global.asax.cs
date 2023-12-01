using System;
using System.Collections.Generic;
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
            string connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__Inscript_v5Context");
            if (!string.IsNullOrEmpty(connectionString))
            {
            var connectionStringsSection = ConfigurationManager.ConnectionStrings["Inscript_v5Context"];
            connectionStringsSection.ConnectionString = connectionString;
            }
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
