namespace TheBookworms.Services.Controllers
{
    using System.Web.Http;
    using Data;
    using Data.UnitOfWork;

    public class BaseApiController : ApiController
    {
        public BaseApiController()
            : this(new BookwormsData(new TheBookwormsContext()))
        {
            
        }

        public BaseApiController(IBookwormsData data)
        {
            this.Data = data;
        }

        protected IBookwormsData Data { get; set; }
    }
}
