namespace TheBookworms.Data.UnitOfWork
{
    using Models;
    using Repositories;

    public interface IBookwormsData
    {
        IRepository<Author> Authors { get; }

        IRepository<Book> Books { get; }

        IRepository<Character> Characters { get; }

        IRepository<Comment> Comments { get; }

        IRepository<CoverImage> CoverImages { get; }

        IRepository<Rating> Ratings { get; }

        IRepository<Review> Reviews { get; }

        IRepository<Status> Statuses { get; }

        IRepository<User> Users { get; }

        IRepository<UserUpdate> UserUpdates { get; }

        int SaveChanges();

    }
}