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

            if (!context.Statuses.Any())
            {
                var status1 = new Status()
                {
                    Text = "to-read"
                };

                context.Statuses.Add(status1);

                var status2 = new Status()
                {
                    Text = "reading"
                };

                context.Statuses.Add(status2);

                var status3 = new Status()
                {
                    Text = "read"
                };

                context.Statuses.Add(status3);

                var status4 = new Status()
                {
                    Text = "none"
                };

                context.Statuses.Add(status4);

                context.SaveChanges();
            }

            if (!context.Authors.Any())
            {
                var author1 = new Author()
                {
                    Name = "Steven King",
                    Biography = "A really cool dude!"
                };

                context.Authors.Add(author1);

                var author2 = new Author()
                {
                    Name = "Terry Pratchett",
                    Biography = "RIP Sir Terry!"
                };

                context.Authors.Add(author2);

                var author3 = new Author()
                {
                    Name = "George R.R. Martin",
                    Biography = "He should finish the books already!"
                };

                context.Authors.Add(author3);

                context.SaveChanges();
            }

            if (!context.Characters.Any())
            {
                var char1 = new Character()
                {
                    Description = "Commander of the City Watch",
                    Name = "Sam Vimes"
                };

                context.Characters.Add(char1);

                var char2 = new Character()
                {
                    Description = "HE KNOWS NOTHING",
                    Name = "Jon Snow"
                };

                context.Characters.Add(char2);

                var char3 = new Character()
                {
                    Description = "The man in black",
                    Name = "Randall Flag"
                };

                context.Characters.Add(char3);

                context.SaveChanges();
            }

            if (!context.Genres.Any())
            {
                var genre1 = new Genre()
                {
                    Text = "fantasy"
                };

                context.Genres.Add(genre1);

                var genre2 = new Genre()
                {
                    Text = "science fiction"
                };

                context.Genres.Add(genre2);

                var genre3 = new Genre()
                {
                    Text = "fiction"
                };

                context.Genres.Add(genre3);

                var genre4 = new Genre()
                {
                    Text = "humour"
                };

                context.Genres.Add(genre4);

                var genre5 = new Genre()
                {
                    Text = "horror"
                };

                context.Genres.Add(genre5);

                context.SaveChanges();
            }

            if (!context.CoverImages.Any())
            {
                var covImage1 = new CoverImage()
                {
                    Url = "https://upload.wikimedia.org/wikipedia/en/8/8d/The_Stand_Uncut.jpg"
                };

                context.CoverImages.Add(covImage1);

                var covImage2 = new CoverImage()
                {
                    Url = "http://vignette1.wikia.nocookie.net/iceandfire/images/b/b6/Game_of_thrones.jpeg"
                };

                context.CoverImages.Add(covImage2);

                var covImage3 = new CoverImage()
                {
                    Url = "http://d.gr-assets.com/books/1431127356l/64216.jpg"
                };

                context.CoverImages.Add(covImage3);

                context.SaveChanges();
            }

            if (!context.Books.Any())
            {
                var book1 = new Book()
                {
                    Title = "The Stand",
                    Description = "The apocalypse is here",
                    Status = context.Statuses.FirstOrDefault(s => s.Text == "none"),
                    CoverImageId = context.CoverImages.FirstOrDefault(c => c.Url == "https://upload.wikimedia.org/wikipedia/en/8/8d/The_Stand_Uncut.jpg").Id,
                };

                book1.Authors.Add(context.Authors.FirstOrDefault(a => a.Name == "Steven King"));
                book1.Characters.Add(context.Characters.FirstOrDefault(ch => ch.Name == "Randall Flag"));
                book1.Genres.Add(context.Genres.FirstOrDefault(g => g.Text == "horror"));
                book1.Genres.Add(context.Genres.FirstOrDefault(g => g.Text == "fantasy"));

                context.Books.Add(book1);

                var book2 = new Book()
                {   
                    Title = "Guards! Guards!",
                    Description = "DRAGON!",
                    Status = context.Statuses.FirstOrDefault(s => s.Text == "none"),
                    CoverImageId = context.CoverImages.FirstOrDefault(c => c.Url == "http://d.gr-assets.com/books/1431127356l/64216.jpg").Id,
                };

                book2.Authors.Add(context.Authors.FirstOrDefault(a => a.Name == "Terry Pratchett"));
                book2.Characters.Add(context.Characters.FirstOrDefault(ch => ch.Name == "Sam Vimes"));
                book2.Genres.Add(context.Genres.FirstOrDefault(g => g.Text == "humour"));
                book2.Genres.Add(context.Genres.FirstOrDefault(g => g.Text == "fantasy"));

                context.Books.Add(book2);

                var book3 = new Book()
                {
                    Title = "A Game of Thrones",
                    Description = "DRAGONS AND SWORDS!",
                    Status = context.Statuses.FirstOrDefault(s => s.Text == "none"),
                    CoverImageId = context.CoverImages.FirstOrDefault(c => c.Url == "http://vignette1.wikia.nocookie.net/iceandfire/images/b/b6/Game_of_thrones.jpeg").Id,
                };

                book3.Authors.Add(context.Authors.FirstOrDefault(a => a.Name == "George R.R. Martin"));
                book3.Characters.Add(context.Characters.FirstOrDefault(ch => ch.Name == "Jon Snow"));
                book3.Genres.Add(context.Genres.FirstOrDefault(g => g.Text == "fantasy"));

                context.Books.Add(book3);

                context.SaveChanges();
            }
        }
    }
}
