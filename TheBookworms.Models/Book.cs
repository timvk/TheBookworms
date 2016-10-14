namespace TheBookworms.Models
{
    using System;
    using System.Collections.Generic;

    public class Book
    {
        private ICollection<Author> authors;
        private ICollection<Rating> ratings;
        private ICollection<Character> characters;
        private ICollection<Genre> genres;
        private ICollection<Review> reviews;
        private ICollection<User> readers;

        public Book()
        {
            this.authors = new HashSet<Author>();
            this.ratings = new HashSet<Rating>();
            this.characters = new HashSet<Character>();
            this.genres = new HashSet<Genre>();
            this.reviews = new HashSet<Review>();
            this.readers = new HashSet<User>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Author> Authors
        {
            get { return this.authors; }
            set { this.authors = value; }
        }

        public string  Description { get; set; }

        public int PagesCount { get; set; }

        public string Publisher { get; set; }

        public DateTime DatePublished { get; set; }

        public DateTime DateAdded { get; set; }

        public int? CoverImageId { get; set; }

        public virtual CoverImage CoverImage { get; set; }

        public int StatusId { get; set; }

        public virtual Status Status { get; set; }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }

        public virtual ICollection<Character> Characters
        {
            get { return this.characters; }
            set { this.characters = value; }
        }

        public virtual ICollection<Genre> Genres
        {
            get { return this.genres; }
            set { this.genres = value; }
        }

        public virtual ICollection<Review> Reviews
        {
            get { return this.reviews; }
            set { this.reviews = value; }
        }


        public virtual ICollection<User> Readers
        {
            get { return this.readers; }
            set { this.readers = value; }
        }
    }
}