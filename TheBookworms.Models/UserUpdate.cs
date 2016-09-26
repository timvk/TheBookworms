namespace TheBookworms.Models
{
    using System;
    using System.Collections.Generic;

    public class UserUpdate
    {
        private ICollection<Comment> comments;

        public UserUpdate()
        {
            this.comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public DateTime DateAdded { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public string Content { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

//        public int BookId { get; set; }
//
//        public virtual Book Book { get; set; }
    }
}