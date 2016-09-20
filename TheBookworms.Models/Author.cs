namespace TheBookworms.Models
{
    using System.Collections.Generic;

    public class Author
    {
        private ICollection<Book> books; 

        public Author()
        {
            this.books = new HashSet<Book>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Biography { get; set; }

        public virtual ICollection<Book> Books
        {
            get { return this.books; }
            set { this.books = value; }
        }
    }
}
