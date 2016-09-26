namespace TheBookworms.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TheBookwormsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TheBookwormsContext context)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                roleManager.Create(new IdentityRole("Admin"));
            }

            if (!context.Users.Any())
            {
                var userManager = new UserManager<User>(new UserStore<User>(context));

                //TODO: add admin
                var user1 = new User()
                {
                    UserName = "kokobe",
                    Email = "kokobe@koko.be",
                    Age = 20,
                    About = "winter is coming"
                };

                userManager.Create(user1, "kokobe");

                userManager = new UserManager<User>(new UserStore<User>(context));

                var user2 = new User()
                {
                    UserName = "pacobe",
                    Email = "paco@paco.be",
                    Age = 25,
                    About = "don't panic"
                };

                userManager.Create(user2, "pacobe");

                userManager = new UserManager<User>(new UserStore<User>(context));

                var user3 = new User()
                {
                    UserName = "bobobe",
                    Email = "bobo@bobo.be",
                    Age = 25,
                    About = "playaaah"
                };

                userManager.Create(user3, "bobobe");
            }

            if (!context.Authors.Any())
            {
                
            }
        }
    }
}
