namespace TheBookworms.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using TheBookworms.Models;

    public class BookDetailsViewModel : BookViewModel
    {
        public int PagesCount { get; set; }

        public string Publisher { get; set; }

        public DateTime DatePublished { get; set; }

        public IEnumerable<string> Characters { get; set; }

        public int ReviewsCount { get; set; }

        public new static Expression<Func<Book, BookDetailsViewModel>> Create
        {
            get
            {
                return b => new BookDetailsViewModel()
                {
                    Id = b.Id,
                    TItle = b.Title,
                    Description = b.Description,
                    ImageUrl = b.CoverImage.Url,
                    Status = b.Status.Text,
                    AverageRating = b.Ratings.Average(r => r.Value),
                    Authors = b.Authors
                        .OrderBy(a => a.Name)
                        .Select(a => new AuthorViewModel()
                        {
                            Id = a.Id,
                            Name = a.Name
                        }),
                    Genres = b.Genres
                        .OrderBy(g => g.Text)
                        .Select(g => new GenreViewModel()
                        {
                            Id = g.Id,
                            Text = g.Text
                        }),
                    PagesCount = b.PagesCount,
                    Publisher = b.Publisher,
                    DatePublished = b.DatePublished,
                    Characters = b.Characters
                        .OrderBy(ch => ch.Name)
                        .Select(ch => ch.Name),
                    ReviewsCount = b.Reviews.Count
                };
            }
        } 
    }
}