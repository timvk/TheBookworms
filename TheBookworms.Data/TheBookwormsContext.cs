namespace TheBookworms.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;
    using Models;

    public class TheBookwormsContext : IdentityDbContext<User>
    {
        public TheBookwormsContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<TheBookwormsContext, Configuration>());
        }

        public virtual IDbSet<Book> Books { get; set; }

        public virtual IDbSet<Author> Authors { get; set; }

        public virtual IDbSet<Character> Characters { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<CoverImage> CoverImages { get; set; }

        public virtual IDbSet<Genre> Genres { get; set; }

        public virtual IDbSet<Rating> Ratings { get; set; }

        public virtual IDbSet<Review> Reviews { get; set; }

        public virtual IDbSet<Status> Statuses { get; set; }

        public virtual IDbSet<UserUpdate> UserUpdates { get; set; }

        public static TheBookwormsContext Create()
        {
            return new TheBookwormsContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasKey(b => b.Id)
                .HasOptional(b => b.CoverImage)
                .WithOptionalPrincipal(ci => ci.Book);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id)
                .HasOptional(u => u.Image)
                .WithOptionalPrincipal(ci => ci.User);

            base.OnModelCreating(modelBuilder);
        }
    }
}