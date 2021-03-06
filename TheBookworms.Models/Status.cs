﻿namespace TheBookworms.Models
{
    using System.Collections.Generic;

    public class Status
    {
        private ICollection<Book> books;

        public Status()
        {
            this.books = new HashSet<Book>();
        }

        public int Id { get; set; }

        public string Text { get; set; }

        public virtual ICollection<Book> Books
        {
            get { return this.books; }
            set { this.books = value; }
        }
    }
}