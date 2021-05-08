using System.Web.Mvc;
using System.Web.Routing;

namespace DevFramework.Northwind.Mvc.WebUI.Tests
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}