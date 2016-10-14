namespace TheBookworms.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Models;
    using TheBookworms.Models;

    public class BooksController : BaseApiController
    {
        //GET api/books
        [HttpGet]
        [Route("api/books")]
        public IHttpActionResult GetAllBooks()
        {
            var books = this.Data.Books.All()
                .OrderBy(b => b.DateAdded)
                .ThenBy(b => b.Title)
                .Select(BookViewModel.Create);

            return this.Ok(books);
        }
        
        [HttpGet]
        [Route("api/books/{id}")]
        public IHttpActionResult GetBookById(int id)
        {
            var book = this.Data.Books.All()
                .OrderBy(b => b.Id)
                .Where(b => b.Id == id)
                .Select(BookDetailsViewModel.Create)
                .FirstOrDefault();

            return this.Ok(book);
        }
    }
}
