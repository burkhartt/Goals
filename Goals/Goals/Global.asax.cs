
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Goals.Controllers;
using Goals.Filters;
using Goals.Repositories;
using Goals.SessionState;
using IActionFilter = System.Web.Mvc.IActionFilter;

namespace Goals {    
    public class MvcApplication : HttpApplication {        
        protected void Application_Start() {
            


            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.Register(c => new Session(HttpContext.Current.Session)).As<ISession>();
                
            builder.RegisterType<ImportModelStateFromTempData>().As<IActionFilter>();
            builder.RegisterType<ExportModelStateToTempData>().As<IActionFilter>();

            builder.RegisterType<ExtensibleActionInvoker>().As<IActionInvoker>();

            builder.RegisterGeneric(typeof (SessionRepository<>)).As(typeof (IRepository<>));
            builder.RegisterFilterProvider();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}