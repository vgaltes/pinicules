using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Pinicules.Domain.Services;
using Pinicules.Domain.Repositories;
using Pinicules.Data.Repositories;

namespace Pinicules.Presentation
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            container.RegisterTypes(AllClasses.FromLoadedAssemblies(),
                                    WithMappings.FromMatchingInterface,
                                    WithName.Default);
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}