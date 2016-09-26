namespace TheBookworms.Models
{
    public class CoverImage
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int? BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}
