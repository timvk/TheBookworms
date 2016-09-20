namespace TheBookworms.Models
{
    using System.Collections.Generic;

    public class Character
    {
        private ICollection<Book> books; 

        public Character()
        {
            this.books = new HashSet<Book>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Book> Books
        {
            get { return this.books; }
            set { this.books = value; }
        }
    }
}