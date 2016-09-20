namespace TheBookworms.Models
{
    using System;

    public class Comment
    {
        public int Id { get; set; }

        public DateTime DateAdded { get; set; }

        public int? ReviewId { get; set; }

        public virtual Review Review { get; set; }

        public int? UserUpdateId { get; set; }

        public virtual UserUpdate UserUpdate { get; set; }
    }
}