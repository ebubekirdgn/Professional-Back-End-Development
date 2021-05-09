using DevFramework.Core.Utilities.Mvc.Infrastructure;
using DevFramework.Northwind.Business.DependencyResolves.Ninject;
using System.Web.Mvc;
using System.Web.Routing;

namespace DevFramework.Nortwind.MvcWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule()));
        }
    }
}