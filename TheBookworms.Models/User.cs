﻿namespace TheBookworms.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        private ICollection<Book> books;
        private ICollection<UserUpdate> updates;
        private ICollection<Rating> ratings;
        private ICollection<Review> reviews;
        private ICollection<Comment> comments;

        public User()
        {
            this.books = new HashSet<Book>();
            this.updates = new HashSet<UserUpdate>();
            this.ratings = new HashSet<Rating>();
            this.reviews = new HashSet<Review>();
            this.comments = new HashSet<Comment>();
        }
        public int Age { get; set; }

        public string About { get; set; }

        public int ImageId { get; set; }

        public virtual CoverImage Image { get; set; }

        public virtual ICollection<Book> Books
        {
            get { return this.books; }
            set { this.books = value; }
        }

        public virtual ICollection<UserUpdate> Updates
        {
            get { return this.updates; }
            set { this.updates = value; }
        }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }

        public virtual ICollection<Review> Reviews
        {
            get { return this.reviews; }
            set { this.reviews = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}