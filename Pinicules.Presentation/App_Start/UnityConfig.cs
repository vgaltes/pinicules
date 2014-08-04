using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Pinicules.Domain.Services;
using Pinicules.Domain.Repositories;
using Pinicules.Infrastructure.Repositories;

namespace Pinicules.Presentation
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IMoviesRepository, InMemoryMoviesRepository>();
            container.RegisterTypes(AllClasses.FromLoadedAssemblies(),
                                    WithMappings.FromMatchingInterface,
                                    WithName.Default);
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}