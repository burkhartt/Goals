using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using FluentValidation;
using FluentValidation.Mvc;
using Goals.Databases;
using Goals.Filters;
using Goals.Repositories;
using Goals.Validation;
using IActionFilter = System.Web.Mvc.IActionFilter;

namespace Goals {
    public class MvcApplication : HttpApplication {
        protected void Application_Start() {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof (MvcApplication).Assembly);

            builder.RegisterType<Database>().As<IDatabase>();

            builder.RegisterType<ImportModelStateFromTempData>().As<IActionFilter>();
            builder.RegisterType<ExportModelStateToTempData>().As<IActionFilter>();

            builder.RegisterType<ExtensibleActionInvoker>().As<IActionInvoker>();            
            builder.RegisterGeneric(typeof (DatabaseRepository<>)).As(typeof (IRepository<>));
            builder.RegisterFilterProvider();

            builder.RegisterType<ModelValidatorFactory>().As<IValidatorFactory>();
            var findValidatorsInAssembly = AssemblyScanner.FindValidatorsInAssembly(Assembly.GetExecutingAssembly());
            foreach (var item in findValidatorsInAssembly) {
                builder.RegisterType(item.ValidatorType).As(item.InterfaceType);
            }

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            ModelValidatorProviders.Providers.Add(
                new FluentValidationModelValidatorProvider(container.Resolve<IValidatorFactory>()));

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}