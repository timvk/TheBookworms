namespace TheBookworms.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using TheBookworms.Models;

    public class BookViewModel
    {
        public int Id { get; set; }

        public string TItle { get; set; }

        public string Description { get; set; }

        public IEnumerable<AuthorViewModel> Authors { get; set; }

        public string ImageUrl { get; set; }

        public string Status { get; set; }

        public double AverageRating { get; set; }

        public IEnumerable<GenreViewModel> Genres { get; set; }

        public static Expression<Func<Book, BookViewModel>> Create
        {
            get
            {
                return b => new BookViewModel()
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
                        })
                };
            }
        } 
    }
}