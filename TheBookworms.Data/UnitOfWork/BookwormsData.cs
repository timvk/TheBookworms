namespace TheBookworms.Data.UnitOfWork
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using Models;
    using Repositories;

    public class BookwormsData : IBookwormsData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public BookwormsData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }


        public IRepository<Author> Authors
        {
            get { return this.GetRepository<Author>(); }
        }

        public IRepository<Book> Books
        {
            get { return this.GetRepository<Book>(); }
        }

        public IRepository<Character> Characters
        {
            get { return this.GetRepository<Character>(); }
        }

        public IRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
        }

        public IRepository<CoverImage> CoverImages
        {
            get { return this.GetRepository<CoverImage>(); }
        }

        public IRepository<Rating> Ratings
        {
            get { return this.GetRepository<Rating>(); }
        }

        public IRepository<Review> Reviews
        {
            get { return this.GetRepository<Review>(); }
        }

        public IRepository<Status> Statuses
        {
            get { return this.GetRepository<Status>(); }
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<UserUpdate> UserUpdates
        {
            get { return this.GetRepository<UserUpdate>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(GenericRepository<T>);
                var repository = Activator.CreateInstance(
                    typeOfRepository, this.context);

                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }

    }
}