namespace TheBookworms.Models
{
    public class Rating
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}