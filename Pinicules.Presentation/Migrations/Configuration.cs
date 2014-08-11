namespace Pinicules.Presentation.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Pinicules.Presentation.Identity;

    internal sealed class Configuration : DbMigrationsConfiguration<AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Pinicules.Presentation.Identity.AppDbContext";
        }

        protected override void Seed(AppDbContext context)
        {
            //context.Roles.AddOrUpdate(new IdentityRole[] { new IdentityRole("Admin") });
            CreateRole("Admin");

            AddAdminUser(context, "vicente", "peliculas");
            AddAdminUser(context, "vincent", "pelicules");
        }

        private void CreateRole(string roleName)
        {
            var rm = new RoleManager<IdentityRole>(
            new RoleStore<IdentityRole>(new AppDbContext()));
            var idResult = rm.Create(new IdentityRole(roleName));
        }

        private static void AddAdminUser(AppDbContext context, string userName, string password)
        {
            var userStore = new UserStore<AppUser>(
                    new AppDbContext());
            var manager = new UserManager<AppUser>(
                userStore);
            var user = manager.FindByName(userName);
            if ( user == null ){
                manager.Create(new AppUser { UserName = userName }, password);
            }

            user = manager.FindByName(userName);
            manager.AddToRole(user.Id, "Admin");
        }
    }
}
