using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Pinicules.Domain.Services;
using Pinicules.Domain.Repositories;
using Pinicules.Data.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Pinicules.Presentation.Identity;

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

            var userManager = new UserManager<AppUser>(
                new UserStore<AppUser>(new AppDbContext()));

            userManager.UserValidator = new UserValidator<AppUser>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };

            container.RegisterInstance<UserManager<AppUser>>(userManager);
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}