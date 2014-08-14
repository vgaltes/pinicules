using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Pinicules.Domain.Services;
using Pinicules.Domain.Repositories;
using Pinicules.Data.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Pinicules.Presentation.Identity;
using Pinicules.Presentation.Controllers;
using Pinicules.Data.Infrastructure;

namespace Pinicules.Presentation
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            //container.RegisterTypes(AllClasses.FromLoadedAssemblies(),
            //                        WithMappings.FromMatchingInterface,
            //                        WithName.Default);

            container.RegisterType<IMoviesContext, MoviesContext>();
            container.RegisterType<IMoviesRepository, MoviesRepository>();
            container.RegisterType<ITmdbRepository, TmdbRepository>();
            container.RegisterType<IMoviesService, MoviesService>();
            container.RegisterType<MoviesController>();
            container.RegisterType<AuthController>();

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