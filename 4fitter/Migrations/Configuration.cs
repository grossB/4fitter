namespace _4fitter.Migrations
{
    using _4fitter.Utilities;
    using _4fitter.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_4fitter.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(_4fitter.Models.ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == Definitions.ROLE_ADMIN))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = Definitions.ROLE_ADMIN };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin@4fitter.pl"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "admin@4fitter.pl", Email = "admin@4fitter.pl" };

                manager.Create(user, "Admin!1");
                manager.AddToRole(user.Id, Definitions.ROLE_ADMIN);
            }
        }
    }
}
